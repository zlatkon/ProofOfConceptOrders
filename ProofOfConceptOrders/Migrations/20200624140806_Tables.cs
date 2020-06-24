using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProofOfConceptOrders.Migrations
{
    public partial class Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Application = table.Column<string>(nullable: true),
                    WmsOrderId = table.Column<Guid>(nullable: false),
                    OrderNumber = table.Column<string>(nullable: false),
                    TransportNumber = table.Column<string>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: false),
                    Customer = table.Column<string>(nullable: false),
                    Haulier = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    ArrivalDate = table.Column<DateTime>(nullable: true),
                    IsAutomaticInvoicingAllowed = table.Column<bool>(nullable: false),
                    IsInvoiced = table.Column<bool>(nullable: false),
                    IsCancelled = table.Column<bool>(nullable: false),
                    CountryOfArrival = table.Column<string>(nullable: true),
                    CountryOfDeparture = table.Column<string>(nullable: true),
                    Site = table.Column<string>(nullable: true),
                    StockLines = table.Column<string>(nullable: true),
                    Actions = table.Column<string>(nullable: true),
                    Properties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceOrders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceOrders");
        }
    }
}
