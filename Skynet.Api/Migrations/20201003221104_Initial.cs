using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skynet.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Countrie__10D1609F889C5CE3", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    FirstName = table.Column<string>(maxLength: 32, nullable: false),
                    LastName = table.Column<string>(maxLength: 32, nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CC4C7EA6D238", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    AirlineId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Abbreviation = table.Column<string>(maxLength: 16, nullable: false),
                    CountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Airlines__DC4582136FF68F6F", x => x.AirlineId);
                    table.ForeignKey(
                        name: "FK__Airlines__Countr__398D8EEE",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(nullable: false),
                    AirlineId = table.Column<Guid>(nullable: false),
                    OriginCountryId = table.Column<int>(nullable: false),
                    DestinationCountryId = table.Column<int>(nullable: false),
                    Departure = table.Column<DateTime>(nullable: false),
                    Arrival = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Flights__8A9E14EE3F8B4862", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK__Flights__Airline__3C69FB99",
                        column: x => x.AirlineId,
                        principalTable: "Airlines",
                        principalColumn: "AirlineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Flights__Destina__3E52440B",
                        column: x => x.DestinationCountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Flights__OriginC__3D5E1FD2",
                        column: x => x.OriginCountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserFlights",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    FlightId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFlights", x => new { x.UserId, x.FlightId });
                    table.ForeignKey(
                        name: "FK_Flights",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, "Israel" },
                    { 2, "USA" },
                    { 3, "UK" },
                    { 4, "Japan" }
                });

            migrationBuilder.InsertData(
                table: "Airlines",
                columns: new[] { "AirlineId", "Abbreviation", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("a54e4ceb-9005-4768-978f-22f0c010829b"), "ELAL", 1, "El Al" },
                    { new Guid("831251dc-06f3-4557-a6bb-edbe7371c253"), "DAL", 2, "Delta Air Lines" },
                    { new Guid("a308f4d3-656a-43ab-bd44-075934278426"), "AAL", 2, "American Airlines" },
                    { new Guid("cac3d5f7-43d8-4d71-9041-c2cae939d311"), "BRA", 3, "British Airways" },
                    { new Guid("3c8ae801-6e2e-42d9-9254-277b284d72c5"), "VRA", 3, "Virgin Atlantic" },
                    { new Guid("6739c7b3-b0f4-42ac-a8c8-7732cb4983e8"), "JAL", 4, "Japan Airlines" },
                    { new Guid("75c8b747-e2de-4aa7-a6d4-f19e6816244b"), "ANA", 4, "All Nippon Airways" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airlines_CountryId",
                table: "Airlines",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries",
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirlineId",
                table: "Flights",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DestinationCountryId",
                table: "Flights",
                column: "DestinationCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_OriginCountryId",
                table: "Flights",
                column: "OriginCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights",
                table: "Flights",
                columns: new[] { "FlightId", "AirlineId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFlights_FlightId",
                table: "UserFlights",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Users",
                table: "Users",
                columns: new[] { "UserId", "FirstName", "LastName" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFlights");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
