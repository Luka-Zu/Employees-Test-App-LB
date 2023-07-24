using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudAPI.Migrations
{
    /// <inheritdoc />
    public partial class personallid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonalNumber",
                table: "Employees",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PersonalNumber",
                table: "Employees",
                column: "PersonalNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_PersonalNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PersonalNumber",
                table: "Employees");
        }
    }
}
