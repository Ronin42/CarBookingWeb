using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBooking.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddBookedSeatsToCardb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookedSeats",
                table: "Cars",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookedSeats",
                table: "Cars");
        }
    }
}
