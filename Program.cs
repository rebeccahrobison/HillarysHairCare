using HillarysHairCare.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using HillarysHairCare.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<HillarysHairCareDbContext>(builder.Configuration["HillarysHairCareDbConnectionString"]);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//ENDPOINTS SECTION

// Get all Appointments
app.MapGet("/api/appointments", (HillarysHairCareDbContext db) =>
{
    return db.Appointments
        .Include(a => a.Services)
        .OrderBy(a => a.ApptTime)
        .Select(a => new AppointmentDTO
        {
            Id = a.Id,
            StylistId = a.StylistId,
            CustomerId = a.CustomerId,
            ApptTime = a.ApptTime,
            Services = a.Services.Select(s => new ServiceDTO
            {
                Id = s.Id,
                Name = s.Name,
                Price = s.Price
            }).ToList(),
            Customer = new CustomerDTO
            {
                Id = a.Customer.Id,
                Name = a.Customer.Name,
                Email = a.Customer.Email
            },
            Stylist = new StylistDTO
            {
                Id = a.Stylist.Id,
                Name = a.Stylist.Name,
                Active = a.Stylist.Active
            }
        });
});

// Get appointment by id
app.MapGet("/api/appointments/{id}", (HillarysHairCareDbContext db, int id) =>
{

    List<Service> foundServices = db.AppointmentServices
        .Where(apt => apt.AppointmentId == id)
        .Join(db.Services,
        apt => apt.ServiceId,
        s => s.Id,
        (apt, s) => s).ToList();

    Appointment foundAppointment = db.Appointments
        .Include(a => a.Stylist)
        .Include(a => a.Customer)
        .FirstOrDefault(a => a.Id == id);

    //error handler
    if (foundAppointment == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(new AppointmentDTO
    {
        Id = foundAppointment.Id,
        StylistId = foundAppointment.StylistId,
        CustomerId = foundAppointment.CustomerId,
        ApptTime = foundAppointment.ApptTime,
        Services = foundServices.Select(s => new ServiceDTO
        {
            Id = s.Id,
            Name = s.Name,
            Price = s.Price
        }).ToList(),
        Customer = new CustomerDTO
        {
            Id = foundAppointment.Customer.Id,
            Name = foundAppointment.Customer.Name,
            Email = foundAppointment.Customer.Email
        },
        Stylist = new StylistDTO
        {
            Id = foundAppointment.Stylist.Id,
            Name = foundAppointment.Stylist.Name,
            Active = foundAppointment.Stylist.Active
        }
    });
});

// Add an appointment
app.MapPost("/api/appointments", (HillarysHairCareDbContext db, Appointment appointment) =>
{
    var apptToAdd = new Appointment
    {
        StylistId = appointment.StylistId,
        CustomerId = appointment.CustomerId,
        ApptTime = appointment.ApptTime
    };

    db.Appointments.Add(apptToAdd);
    db.SaveChanges();

    foreach (var service in appointment.Services)
    {
        var aService = new AppointmentService
        {
            AppointmentId = apptToAdd.Id,
            ServiceId = service.Id
        };
        db.AppointmentServices.Add(aService);
    }

    db.SaveChanges();

    return Results.Created($"/api/appointments/{appointment.Id}", appointment);
});

// Cancel an appointment
app.MapDelete("/api/appointments/{id}", (HillarysHairCareDbContext db, int id) =>
{
    Appointment foundAppointment = db.Appointments.FirstOrDefault(a => a.Id == id);

    if (foundAppointment == null)
    {
        return Results.NotFound();
    }

    db.Appointments.Remove(foundAppointment);
    db.SaveChanges();
    return Results.NoContent();
});

// Create an Appointment Service
app.MapPost("/api/appointmentservices", (HillarysHairCareDbContext db, AppointmentService appointmentService) =>
{
    db.AppointmentServices.Add(appointmentService);
    db.SaveChanges();
    return Results.Created($"/api/appointmentservices/{appointmentService.Id}", appointmentService);
});

// Delete an Appointment Service
app.MapDelete("/api/appointmentservices/{id}", (HillarysHairCareDbContext db, int id) =>
{
    AppointmentService foundAS = db.AppointmentServices.FirstOrDefault(a => a.Id == id);

    if (foundAS == null)
    {
        return Results.NotFound();
    }

    db.AppointmentServices.Remove(foundAS);
    db.SaveChanges();
    return Results.NoContent();
});

// Get all Stylists
app.MapGet("/api/stylists", (HillarysHairCareDbContext db) =>
{
    return db.Stylists
            .Select(s => new
            {
                Stylist = new StylistDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    Active = s.Active
                },
                Appointments = db.Appointments
                    .Where(a => a.StylistId == s.Id)
                    .Select(a => new AppointmentDTO
                    {
                        Id = a.Id,
                        StylistId = a.StylistId,
                        CustomerId = a.CustomerId,
                        ApptTime = a.ApptTime,
                        Services = a.Services.Select(s => new ServiceDTO
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Price = s.Price
                        }).ToList(),
                    })
                    .ToList()
            });
});

// Deactivate a stylist
app.MapPost("/api/stylists/{id}/deactivate", (HillarysHairCareDbContext db, int id) =>
{
    Stylist stylistToDeactivate = db.Stylists.SingleOrDefault(s => s.Id == id);
    if (stylistToDeactivate == null)
    {
        return Results.NotFound();
    }

    stylistToDeactivate.Active = false;
    db.SaveChanges();
    return Results.Ok($"{stylistToDeactivate.Name} is deactivated");
});

// Add a new Stylist
app.MapPost("/api/stylists", (HillarysHairCareDbContext db, Stylist stylist) => 
{
    db.Stylists.Add(stylist);
    db.SaveChanges();
    return Results.Created($"/api/stylists/{stylist.Id}", stylist);
});

// Get all Customers
app.MapGet("/api/customers", (HillarysHairCareDbContext db) =>
{
    return db.Customers.Select(c => new CustomerDTO
    {
        Id = c.Id,
        Name = c.Name,
        Email = c.Email
    });
});

// Get all Services
app.MapGet("/api/services", (HillarysHairCareDbContext db) =>
{
    return db.Services.Select(s => new ServiceDTO
    {
        Id = s.Id,
        Name = s.Name,
        Price = s.Price
    });
});

// Get all appointment services
app.MapGet("/api/appointmentservices", (HillarysHairCareDbContext db) =>
{
    return db.AppointmentServices.Select(s => new AppointmentServiceDTO
    {
        Id = s.Id,
        AppointmentId = s.AppointmentId,
        ServiceId = s.ServiceId
    });
});

app.Run();

