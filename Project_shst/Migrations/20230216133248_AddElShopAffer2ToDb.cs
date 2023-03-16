using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_shst.Migrations
{
    /// <inheritdoc />
    public partial class AddElShopAffer2ToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElShopAffer2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ELProductsId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElShopAffer2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElShopAffer2_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElShopAffer2_ELProductAffer_ELProductsId",
                        column: x => x.ELProductsId,
                        principalTable: "ELProductAffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElShopAffer2_ApplicationUserId",
                table: "ElShopAffer2",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ElShopAffer2_ELProductsId",
                table: "ElShopAffer2",
                column: "ELProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElShopAffer2");
        }
    }
}
