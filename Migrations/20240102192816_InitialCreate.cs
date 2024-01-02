using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HillarysHairCare.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StylistId = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    ApptTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppointmentId = table.Column<int>(type: "integer", nullable: false),
                    ServiceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stylists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stylists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    AppointmentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AppointmentServices",
                columns: new[] { "Id", "AppointmentId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 1 },
                    { 4, 2, 3 },
                    { 5, 3, 4 },
                    { 6, 3, 6 },
                    { 7, 4, 5 },
                    { 8, 5, 8 },
                    { 9, 5, 9 },
                    { 10, 6, 1 },
                    { 11, 7, 8 },
                    { 12, 7, 9 },
                    { 13, 7, 10 },
                    { 14, 8, 1 },
                    { 15, 8, 4 },
                    { 16, 9, 1 },
                    { 17, 9, 5 },
                    { 18, 10, 1 },
                    { 19, 10, 1 },
                    { 20, 11, 7 }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "ApptTime", "CustomerId", "StylistId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2024, 1, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, new DateTime(2024, 1, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 4, new DateTime(2024, 1, 17, 11, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 5, new DateTime(2024, 1, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), 5, 5 },
                    { 6, new DateTime(2024, 1, 6, 16, 0, 0, 0, DateTimeKind.Unspecified), 6, 6 },
                    { 7, new DateTime(2024, 1, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), 7, 7 },
                    { 8, new DateTime(2024, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 8, 8 },
                    { 9, new DateTime(2024, 1, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), 9, 9 },
                    { 10, new DateTime(2024, 1, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "verac@gmail.com", "Vera Carter" },
                    { 2, "liamj@gmail.com", "Liam Johnson" },
                    { 3, "avad@gmail.com", "Ava Davis" },
                    { 4, "noahm@gmail.com", "Noah Miller" },
                    { 5, "oliviaw@gmail.com", "Olivia Wilson" },
                    { 6, "emmat@gmail.com", "Emma Thompson" },
                    { 7, "jacksona@gmail.com", "Jackson Anderson" },
                    { 8, "sophiaw@gmail.com", "Sophia White" },
                    { 9, "lucasm@gmail.com", "Lucas Martinez" },
                    { 10, "isabellag@gmail.com", "Isabella Garcia" },
                    { 11, "aidens@gmail.com", "Aiden Smith" },
                    { 12, "miat@gmail.com", "Mia Taylor" },
                    { 13, "calebb@gmail.com", "Caleb Brown" },
                    { 14, "ellaj@gmail.com", "Ella Jones" },
                    { 15, "loganm@gmail.com", "Logan Moore" },
                    { 16, "averyh@gmail.com", "Avery Hall" },
                    { 17, "harpert@gmail.com", "Harper Thomas" },
                    { 18, "benjaminh@gmail.com", "Benjamin Harris" },
                    { 19, "ameliaa@gmail.com", "Amelia Adams" },
                    { 20, "elijahc@gmail.com", "Elijah Clark" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "AppointmentId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, null, "Cut", 50.00m },
                    { 2, null, "Color", 80.00m },
                    { 3, null, "Highlights", 100.00m },
                    { 4, null, "Blowout", 35.00m },
                    { 5, null, "Perm", 70.00m },
                    { 6, null, "Updo", 60.00m },
                    { 7, null, "Extensions", 120.00m },
                    { 8, null, "Manicure", 25.00m },
                    { 9, null, "Pedicure", 35.00m },
                    { 10, null, "Facial", 45.00m }
                });

            migrationBuilder.InsertData(
                table: "Stylists",
                columns: new[] { "Id", "Active", "Name" },
                values: new object[,]
                {
                    { 1, true, "Janet Brown" },
                    { 2, true, "Emily Taylor" },
                    { 3, true, "Michael Black" },
                    { 4, true, "Sophie Harris" },
                    { 5, true, "David Wu" },
                    { 6, true, "Olivia Rodriguez" },
                    { 7, true, "Daniel Johnson" },
                    { 8, true, "Mia Verrt" },
                    { 9, false, "Andrew Wilson" },
                    { 10, false, "Emma Martinez" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_AppointmentId",
                table: "Services",
                column: "AppointmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentServices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Stylists");

            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}
