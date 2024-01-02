using Microsoft.EntityFrameworkCore;
using HillarysHairCare.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;

public class HillarysHairCareDbContext : DbContext
{
  public DbSet<Appointment> Appointments { get; set; }
  public DbSet<AppointmentService> AppointmentServices { get; set; }
  public DbSet<Customer> Customers { get; set; }
  public DbSet<Service> Services { get; set; }
  public DbSet<Stylist> Stylists { get; set; }

  public HillarysHairCareDbContext(DbContextOptions<HillarysHairCareDbContext> context) : base(context)
  {

  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {

    modelBuilder.Entity<Appointment>().HasData(new Appointment[]
    {
        new Appointment 
        {
          Id = 1,
          ApptTime = new DateTime(2024, 1, 15, 9, 0, 0),
          CustomerId = 1,
          StylistId = 1,
        },
        new Appointment
        {
            Id = 2,
            ApptTime = new DateTime(2024, 1, 16, 10, 0, 0),
            CustomerId = 2,
            StylistId = 2,
        },
        new Appointment
        {
            Id = 3,
            ApptTime = new DateTime(2024, 1, 17, 14, 0, 0),
            CustomerId = 3,
            StylistId = 3,
        },
        new Appointment
        {
            Id = 4,
            ApptTime = new DateTime(2024, 1, 17, 11, 0, 0),
            CustomerId = 4,
            StylistId = 4,
        },
        new Appointment
        {
            Id = 5,
            ApptTime = new DateTime(2024, 1, 5, 13, 0, 0),
            CustomerId = 5,
            StylistId = 5,
        },
        new Appointment
        {
            Id = 6,
            ApptTime = new DateTime(2024, 1, 6, 16, 0, 0),
            CustomerId = 6,
            StylistId = 6,
        },
        new Appointment
        {
            Id = 7,
            ApptTime = new DateTime(2024, 1, 8, 14, 0, 0),
            CustomerId = 7,
            StylistId = 7,
        },
        new Appointment
        {
            Id = 8,
            ApptTime = new DateTime(2024, 1, 10, 9, 0, 0),
            CustomerId = 8,
            StylistId = 8,
        },
        new Appointment
        {
            Id = 9,
            ApptTime = new DateTime(2024, 1, 11, 10, 0, 0),
            CustomerId = 9,
            StylistId = 9,
        },
        new Appointment
        {
            Id = 10,
            ApptTime = new DateTime(2024, 1, 10, 15, 0, 0),
            CustomerId = 10,
            StylistId = 10,
        },
    });

    modelBuilder.Entity<AppointmentService>().HasData(new AppointmentService[]
    {
      new AppointmentService {Id = 1, AppointmentId = 1, ServiceId = 1},
      new AppointmentService {Id = 2, AppointmentId = 1, ServiceId = 2},
      new AppointmentService {Id = 3, AppointmentId = 2, ServiceId = 1},
      new AppointmentService {Id = 4, AppointmentId = 2, ServiceId = 3},
      new AppointmentService {Id = 5, AppointmentId = 3, ServiceId = 4},
      new AppointmentService {Id = 6, AppointmentId = 3, ServiceId = 6},
      new AppointmentService {Id = 7, AppointmentId = 4, ServiceId = 5},
      new AppointmentService {Id = 8, AppointmentId = 5, ServiceId = 8},
      new AppointmentService {Id = 9, AppointmentId = 5, ServiceId = 9},
      new AppointmentService {Id = 10, AppointmentId = 6, ServiceId = 1},
      new AppointmentService {Id = 11, AppointmentId = 7, ServiceId = 8},
      new AppointmentService {Id = 12, AppointmentId = 7, ServiceId = 9},
      new AppointmentService {Id = 13, AppointmentId = 7, ServiceId = 10},
      new AppointmentService {Id = 14, AppointmentId = 8, ServiceId = 1},
      new AppointmentService {Id = 15, AppointmentId = 8, ServiceId = 4},
      new AppointmentService {Id = 16, AppointmentId = 9, ServiceId = 1},
      new AppointmentService {Id = 17, AppointmentId = 9, ServiceId = 5},
      new AppointmentService {Id = 18, AppointmentId = 10, ServiceId = 1},
      new AppointmentService {Id = 19, AppointmentId = 10, ServiceId = 1},
      new AppointmentService {Id = 20, AppointmentId = 11, ServiceId = 7},
    });

    modelBuilder.Entity<Customer>().HasData(new Customer[]
    {
      new Customer {Id = 1, Name = "Vera Carter", Email = "verac@gmail.com"},
      new Customer {Id = 2, Name = "Liam Johnson", Email = "liamj@gmail.com"},
      new Customer {Id = 3, Name = "Ava Davis", Email = "avad@gmail.com"},
      new Customer {Id = 4, Name = "Noah Miller", Email = "noahm@gmail.com"},
      new Customer {Id = 5, Name = "Olivia Wilson", Email = "oliviaw@gmail.com"},
      new Customer {Id = 6, Name = "Emma Thompson", Email = "emmat@gmail.com"},
      new Customer {Id = 7, Name = "Jackson Anderson", Email = "jacksona@gmail.com"},
      new Customer {Id = 8, Name = "Sophia White", Email = "sophiaw@gmail.com"},
      new Customer {Id = 9, Name = "Lucas Martinez", Email = "lucasm@gmail.com"},
      new Customer {Id = 10, Name = "Isabella Garcia", Email = "isabellag@gmail.com"},
      new Customer {Id = 11, Name = "Aiden Smith", Email = "aidens@gmail.com"},
      new Customer {Id = 12, Name = "Mia Taylor", Email = "miat@gmail.com"},
      new Customer {Id = 13, Name = "Caleb Brown", Email = "calebb@gmail.com"},
      new Customer {Id = 14, Name = "Ella Jones", Email = "ellaj@gmail.com"},
      new Customer {Id = 15, Name = "Logan Moore", Email = "loganm@gmail.com"},
      new Customer {Id = 16, Name = "Avery Hall", Email = "averyh@gmail.com"},
      new Customer {Id = 17, Name = "Harper Thomas", Email = "harpert@gmail.com"},
      new Customer {Id = 18, Name = "Benjamin Harris", Email = "benjaminh@gmail.com"},
      new Customer {Id = 19, Name = "Amelia Adams", Email = "ameliaa@gmail.com"},
      new Customer {Id = 20, Name = "Elijah Clark", Email = "elijahc@gmail.com"}
    });

    modelBuilder.Entity<Service>().HasData(new Service[]
    {
      new Service {Id = 1, Name = "Cut", Price = 50.00M},
      new Service {Id = 2, Name = "Color", Price = 80.00M},
      new Service {Id = 3, Name = "Highlights", Price = 100.00M},
      new Service {Id = 4, Name = "Blowout", Price = 35.00M},
      new Service {Id = 5, Name = "Perm", Price = 70.00M},
      new Service {Id = 6, Name = "Updo", Price = 60.00M},
      new Service {Id = 7, Name = "Extensions", Price = 120.00M},
      new Service {Id = 8, Name = "Manicure", Price = 25.00M},
      new Service {Id = 9, Name = "Pedicure", Price = 35.00M},
      new Service {Id = 10, Name = "Facial", Price = 45.00M}
    });

    modelBuilder.Entity<Stylist>().HasData(new Stylist[]
    {
        new Stylist {Id = 1, Name = "Janet Brown", Active = true},
        new Stylist {Id = 2, Name = "Emily Taylor", Active = true},
        new Stylist {Id = 3, Name = "Michael Black", Active = true},
        new Stylist {Id = 4, Name = "Sophie Harris", Active = true},
        new Stylist {Id = 5, Name = "David Wu", Active = true},
        new Stylist {Id = 6, Name = "Olivia Rodriguez", Active = true},
        new Stylist {Id = 7, Name = "Daniel Johnson", Active = true},
        new Stylist {Id = 8, Name = "Mia Verrt", Active = true},
        new Stylist {Id = 9, Name = "Andrew Wilson", Active = false},
        new Stylist {Id = 10, Name = "Emma Martinez", Active = false}
    });
  }
}