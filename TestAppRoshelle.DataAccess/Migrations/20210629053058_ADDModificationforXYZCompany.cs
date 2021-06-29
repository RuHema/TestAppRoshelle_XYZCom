using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAppRoshelle.DataAccess.Migrations
{
    public partial class ADDModificationforXYZCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PortOfDischarge",
                table: "Suppliers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ForwarderName",
                table: "Suppliers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "IsActive",
                table: "Suppliers",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsActive",
                table: "ItemProducts",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsActive",
                table: "Categories",
                maxLength: 1,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ItemProducts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "PortOfDischarge",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ForwarderName",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
