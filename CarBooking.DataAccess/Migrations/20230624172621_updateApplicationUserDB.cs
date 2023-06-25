using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBooking.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateApplicationUserDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeNumber",
                table: "AspNetUsers");
        }
    }
}
