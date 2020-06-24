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
                    Json = table.Column<string>(nullable: true),
                    StockLinesJson = table.Column<string>(nullable: true),
                    ActionsJson = table.Column<string>(nullable: true),
                    PropertiesJson = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WmsActionId = table.Column<Guid>(nullable: false),
                    ActionName = table.Column<string>(nullable: true),
                    InvoiceOrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Action_InvoiceOrders_InvoiceOrderId",
                        column: x => x.InvoiceOrderId,
                        principalTable: "InvoiceOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    InvoiceOrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Property_InvoiceOrders_InvoiceOrderId",
                        column: x => x.InvoiceOrderId,
                        principalTable: "InvoiceOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockLine",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WmsStocklineId = table.Column<Guid>(nullable: false),
                    ArticleId = table.Column<Guid>(nullable: false),
                    Product = table.Column<string>(nullable: true),
                    NetWeight = table.Column<string>(nullable: true),
                    GrossWeight = table.Column<string>(nullable: true),
                    Surface = table.Column<string>(nullable: true),
                    Volume = table.Column<string>(nullable: true),
                    Length = table.Column<string>(nullable: true),
                    InvoiceOrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockLine_InvoiceOrders_InvoiceOrderId",
                        column: x => x.InvoiceOrderId,
                        principalTable: "InvoiceOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActionProperty",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    ActionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionProperty_Action_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Action",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockLineAction",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WmsActionId = table.Column<Guid>(nullable: false),
                    ActionName = table.Column<string>(nullable: true),
                    StockLineId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockLineAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockLineAction_StockLine_StockLineId",
                        column: x => x.StockLineId,
                        principalTable: "StockLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockLineProperty",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    StockLineId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockLineProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockLineProperty_StockLine_StockLineId",
                        column: x => x.StockLineId,
                        principalTable: "StockLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockLineActionProperty",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    StockLineActionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockLineActionProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockLineActionProperty_StockLineAction_StockLineActionId",
                        column: x => x.StockLineActionId,
                        principalTable: "StockLineAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Action_InvoiceOrderId",
                table: "Action",
                column: "InvoiceOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionProperty_ActionId",
                table: "ActionProperty",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_InvoiceOrderId",
                table: "Property",
                column: "InvoiceOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_StockLine_InvoiceOrderId",
                table: "StockLine",
                column: "InvoiceOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_StockLineAction_StockLineId",
                table: "StockLineAction",
                column: "StockLineId");

            migrationBuilder.CreateIndex(
                name: "IX_StockLineActionProperty_StockLineActionId",
                table: "StockLineActionProperty",
                column: "StockLineActionId");

            migrationBuilder.CreateIndex(
                name: "IX_StockLineProperty_StockLineId",
                table: "StockLineProperty",
                column: "StockLineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionProperty");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "StockLineActionProperty");

            migrationBuilder.DropTable(
                name: "StockLineProperty");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "StockLineAction");

            migrationBuilder.DropTable(
                name: "StockLine");

            migrationBuilder.DropTable(
                name: "InvoiceOrders");
        }
    }
}
