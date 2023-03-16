using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_shst.Migrations
{
    /// <inheritdoc />
    public partial class addPyment_methodAfferToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipBodyAffer_AspNetUsers_ApplicationUserId",
                table: "ShipBodyAffer");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ShipBodyAffer",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Pyment_methodAffer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pymeny_methodId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pyment_methodAffer", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ShipBodyAffer_AspNetUsers_ApplicationUserId",
                table: "ShipBodyAffer",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipBodyAffer_AspNetUsers_ApplicationUserId",
                table: "ShipBodyAffer");

            migrationBuilder.DropTable(
                name: "Pyment_methodAffer");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ShipBodyAffer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipBodyAffer_AspNetUsers_ApplicationUserId",
                table: "ShipBodyAffer",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
