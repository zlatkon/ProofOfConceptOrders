using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProofOfConceptOrders.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrdersId",
                table: "InvoiceOrders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Orders = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceOrders_OrdersId",
                table: "InvoiceOrders",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceOrders_Orders_OrdersId",
                table: "InvoiceOrders",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceOrders_Orders_OrdersId",
                table: "InvoiceOrders");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceOrders_OrdersId",
                table: "InvoiceOrders");

            migrationBuilder.DropColumn(
                name: "OrdersId",
                table: "InvoiceOrders");
        }
    }
}
