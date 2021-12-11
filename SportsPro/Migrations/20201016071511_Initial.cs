using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsPro.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductCode = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    YearlyPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    TechnicianID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.TechnicianID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    CountryID = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    TechnicianID = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    DateOpened = table.Column<DateTime>(nullable: false),
                    DateClosed = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentID);
                    table.ForeignKey(
                        name: "FK_Incidents_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Technicians_TechnicianID",
                        column: x => x.TechnicianID,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "AU", "Australia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "NZ", "New Zealand" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "NG", "Nigeria" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "PH", "Philippines" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "PR", "Puerto Rico" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "QA", "Qatar" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "SG", "Singapore" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "ES", "Spain" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "SE", "Sweden" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "CH", "Switzerland" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "TH", "Thailand" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "TR", "Turkey" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "UA", "Ukraine" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "AE", "United Arab Emirates" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "GB", "United Kingdom" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "US", "United States" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "VN", "Vietnam" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "ZW", "Zimbabwe" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "NL", "Netherlands" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "MX", "Mexico" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "PT", "Portugal" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "LR", "Liberia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "AT", "Austria" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "BE", "Belgium" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "BR", "Brazil" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "MY", "Malaysia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "CN", "China" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "DK", "Denmark" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "FI", "Finland" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "FR", "France" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "GR", "Greece" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "CA", "Canada" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "HK", "Hong Kong" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "IS", "Iceland" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "IN", "India" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "IE", "Ireland" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "IL", "Israel" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "IT", "Italy" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "JP", "Japan" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[] { "GL", "Greenland" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Name", "ProductCode", "ReleaseDate", "YearlyPrice" },
                values: new object[] { 7, "Tournament Master 2.0", "TRNY20", new DateTime(2018, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.99m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Name", "ProductCode", "ReleaseDate", "YearlyPrice" },
                values: new object[] { 6, "Tournament Master 1.0", "TRNY10", new DateTime(2015, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Name", "ProductCode", "ReleaseDate", "YearlyPrice" },
                values: new object[] { 5, "Team Manager 1.0", "TEAM10", new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Name", "ProductCode", "ReleaseDate", "YearlyPrice" },
                values: new object[] { 2, "Draft Manager 2.0", "DRAFT20", new DateTime(2019, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.99m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Name", "ProductCode", "ReleaseDate", "YearlyPrice" },
                values: new object[] { 3, "League Scheduler 1.0", "LEAG10", new DateTime(2016, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Name", "ProductCode", "ReleaseDate", "YearlyPrice" },
                values: new object[] { 1, "Draft Manager 1.0", "DRAFT10", new DateTime(2017, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Name", "ProductCode", "ReleaseDate", "YearlyPrice" },
                values: new object[] { 4, "League Scheduler Deluxe 1.0", "LEAGD10", new DateTime(2016, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.99m });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "TechnicianID", "Email", "Name", "Phone" },
                values: new object[] { 14, "gunter@sportsprosoftware.com", "Gunter Wendt", "800-555-0400" });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "TechnicianID", "Email", "Name", "Phone" },
                values: new object[] { 11, "alison@sportsprosoftware.com", "Alison Diaz", "800-555-0443" });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "TechnicianID", "Email", "Name", "Phone" },
                values: new object[] { 12, "jason@sportsprosoftware.com", "Jason Lee", "800-555-0444" });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "TechnicianID", "Email", "Name", "Phone" },
                values: new object[] { 13, "awilson@sportsprosoftware.com", "Andrew Wilson", "800-555-0449" });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "TechnicianID", "Email", "Name", "Phone" },
                values: new object[] { 15, "gfiori@sportsprosoftware.com", "Gina Fiori", "800-555-0459" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "City", "CountryID", "Email", "FirstName", "LastName", "Phone", "PostalCode", "State" },
                values: new object[] { 1002, "PO Box 96621", "Washington", "US", "ania@mma.nidc.com", "Ania", "Irvin", "(301) 555-8950", "20090", "DC" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "City", "CountryID", "Email", "FirstName", "LastName", "Phone", "PostalCode", "State" },
                values: new object[] { 1004, "1990 Westwood Blvd Ste 260", "Los Angeles", "US", "kenzie@mma.jobtrak.com", "Kenzie", "Quinn", "(800) 555-8725", "90025", "CA" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "City", "CountryID", "Email", "FirstName", "LastName", "Phone", "PostalCode", "State" },
                values: new object[] { 1006, "3255 Ramos Cir", "Sacramento", "US", "amauro@yahoo.org", "Anton", "Mauro", "(916) 555-6670", "95827", "CA" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "City", "CountryID", "Email", "FirstName", "LastName", "Phone", "PostalCode", "State" },
                values: new object[] { 1008, "Box 52001", "San Francisco", "US", "kanthoni@pge.com", "Kaitlyn", "Anthoni", "(800) 555-6081", "94152", "CA" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "City", "CountryID", "Email", "FirstName", "LastName", "Phone", "PostalCode", "State" },
                values: new object[] { 1010, "PO Box 2069", "Fresno", "US", "kmayte@fresno.ca.gov", "Kendall", "Mayte", "(559) 555-9999", "93718", "CA" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "City", "CountryID", "Email", "FirstName", "LastName", "Phone", "PostalCode", "State" },
                values: new object[] { 1012, "4420 N. First Street, Suite 108", "Fresno", "US", "marvin@expedata.com", "Marvin", "Quintin", "(559) 555-9586", "93726", "CA" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "City", "CountryID", "Email", "FirstName", "LastName", "Phone", "PostalCode", "State" },
                values: new object[] { 1015, "27371 Valderas", "Mission Viejo", "US", "", "Gonzalo", "Keeton", "(214) 555-3647", "92691", "CA" });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentID", "CustomerID", "DateClosed", "DateOpened", "Description", "ProductID", "TechnicianID", "Title" },
                values: new object[] { 2, 1002, null, new DateTime(2020, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Received error message 415 while trying to import data from previous version.", 4, 14, "Error importing data" });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentID", "CustomerID", "DateClosed", "DateOpened", "Description", "ProductID", "TechnicianID", "Title" },
                values: new object[] { 1, 1010, new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Media appears to be bad.", 1, 11, "Could not install" });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentID", "CustomerID", "DateClosed", "DateOpened", "Description", "ProductID", "TechnicianID", "Title" },
                values: new object[] { 4, 1010, null, new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Program fails with error code 510, unable to open database.", 3, null, "Error launching program" });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentID", "CustomerID", "DateClosed", "DateOpened", "Description", "ProductID", "TechnicianID", "Title" },
                values: new object[] { 3, 1015, new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Setup failed with code 104.", 6, 15, "Could not install" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryID",
                table: "Customers",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_CustomerID",
                table: "Incidents",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ProductID",
                table: "Incidents",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_TechnicianID",
                table: "Incidents",
                column: "TechnicianID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
