using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBooking.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateCarNameInSeat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarName",
                table: "Seats",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarName",
                table: "Seats");
        }
    }
}
