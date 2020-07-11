using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace Online_Gift_Delivery_Core_Web.Migrations
{
    public partial class GiftDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gift",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: true),
                    ItemPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GiftSender",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderName = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftSender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Charge = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GiftPurchase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiftSenderId = table.Column<int>(nullable: false),
                    GiftId = table.Column<int>(nullable: false),
                    ShippingMethodId = table.Column<int>(nullable: false),
                    Reciever = table.Column<string>(nullable: true),
                    RecieverAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftPurchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiftPurchase_Gift_GiftId",
                        column: x => x.GiftId,
                        principalTable: "Gift",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiftPurchase_GiftSender_GiftSenderId",
                        column: x => x.GiftSenderId,
                        principalTable: "GiftSender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiftPurchase_ShippingMethod_ShippingMethodId",
                        column: x => x.ShippingMethodId,
                        principalTable: "ShippingMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GiftPurchase_GiftId",
                table: "GiftPurchase",
                column: "GiftId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftPurchase_GiftSenderId",
                table: "GiftPurchase",
                column: "GiftSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftPurchase_ShippingMethodId",
                table: "GiftPurchase",
                column: "ShippingMethodId");

            var sqlFile = Path.Combine(".\\DatabaseScripts", @"data.sql");

            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiftPurchase");

            migrationBuilder.DropTable(
                name: "Gift");

            migrationBuilder.DropTable(
                name: "GiftSender");

            migrationBuilder.DropTable(
                name: "ShippingMethod");
        }
    }
}
