using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_shst.Migrations
{
    /// <inheritdoc />
    public partial class addShipBodyAfferAndShipHeadAfferToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShipBodyAffer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipBodyAffer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipBodyAffer_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipHeadAffer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipId = table.Column<int>(type: "int", nullable: false),
                    ELProductsId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipHeadAffer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipHeadAffer_ELProductAffer_ELProductsId",
                        column: x => x.ELProductsId,
                        principalTable: "ELProductAffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipHeadAffer_ShipBodyAffer_ShipId",
                        column: x => x.ShipId,
                        principalTable: "ShipBodyAffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShipBodyAffer_ApplicationUserId",
                table: "ShipBodyAffer",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipHeadAffer_ELProductsId",
                table: "ShipHeadAffer",
                column: "ELProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipHeadAffer_ShipId",
                table: "ShipHeadAffer",
                column: "ShipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShipHeadAffer");

            migrationBuilder.DropTable(
                name: "ShipBodyAffer");
        }
    }
}
