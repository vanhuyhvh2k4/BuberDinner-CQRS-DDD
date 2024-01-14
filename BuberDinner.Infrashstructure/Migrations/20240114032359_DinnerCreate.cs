using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuberDinner.Infrashstructure.Migrations
{
    public partial class DinnerCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dinners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StartedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EndedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Status = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsPublic = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MaxGuest = table.Column<int>(type: "int", nullable: false),
                    Price_Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Price_Currency = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HostId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MenuId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location_Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location_Latitude = table.Column<double>(type: "double", nullable: false),
                    Location_Longitude = table.Column<double>(type: "double", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dinners", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DinnerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    GuestCount = table.Column<int>(type: "int", nullable: false),
                    ReservationStatus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuestId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BillId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ArrivalDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => new { x.DinnerId, x.Id });
                    table.ForeignKey(
                        name: "FK_Reservations_Dinners_DinnerId",
                        column: x => x.DinnerId,
                        principalTable: "Dinners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Dinners");
        }
    }
}
