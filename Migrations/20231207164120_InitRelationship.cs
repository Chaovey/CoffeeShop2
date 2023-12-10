using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop2.Migrations
{
    /// <inheritdoc />
    public partial class InitRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbcustomer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    CustomerId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Order_history = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcustomer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbitem",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    itemId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    size = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbitem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbmenu",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    menuId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbmenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tborder",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    orderId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    orderStatus = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    MenuId = table.Column<string>(type: "varchar(36)", nullable: false),
                    CustomerId = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tborder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tborder_tbcustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "tbcustomer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tborder_tbmenu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "tbmenu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tborderitem",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    orderItemId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    orderId = table.Column<string>(type: "varchar(36)", nullable: false),
                    itemId = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tborderitem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tborderitem_tbitem_itemId",
                        column: x => x.itemId,
                        principalTable: "tbitem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tborderitem_tborder_orderId",
                        column: x => x.orderId,
                        principalTable: "tborder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbpayment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    paymentId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    paymentAmount = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    paymentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CustomerId = table.Column<string>(type: "varchar(36)", nullable: false),
                    orderId = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbpayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbpayment_tbcustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "tbcustomer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbpayment_tborder_orderId",
                        column: x => x.orderId,
                        principalTable: "tborder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tborder_CustomerId",
                table: "tborder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_tborder_MenuId",
                table: "tborder",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_tborderitem_itemId",
                table: "tborderitem",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_tborderitem_orderId",
                table: "tborderitem",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_tbpayment_CustomerId",
                table: "tbpayment",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbpayment_orderId",
                table: "tbpayment",
                column: "orderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tborderitem");

            migrationBuilder.DropTable(
                name: "tbpayment");

            migrationBuilder.DropTable(
                name: "tbitem");

            migrationBuilder.DropTable(
                name: "tborder");

            migrationBuilder.DropTable(
                name: "tbcustomer");

            migrationBuilder.DropTable(
                name: "tbmenu");
        }
    }
}
