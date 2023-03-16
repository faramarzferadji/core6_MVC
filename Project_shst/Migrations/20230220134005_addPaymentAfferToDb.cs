using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_shst.Migrations
{
    /// <inheritdoc />
    public partial class addPaymentAfferToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentAffer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pymeny_methodId = table.Column<int>(type: "int", nullable: false),
                    Cart_Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentAffer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentAffer_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentAffer_Pyment_methodAffer_Pymeny_methodId",
                        column: x => x.Pymeny_methodId,
                        principalTable: "Pyment_methodAffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAffer_ApplicationUserId",
                table: "PaymentAffer",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAffer_Pymeny_methodId",
                table: "PaymentAffer",
                column: "Pymeny_methodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentAffer");
        }
    }
}
