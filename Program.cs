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


app.Run();

