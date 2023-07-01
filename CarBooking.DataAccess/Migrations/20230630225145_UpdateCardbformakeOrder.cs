using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBooking.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCardbformakeOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingOrders_AspNetUsers_ApplicationUserId",
                table: "BookingOrders");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Displayorder",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Distance",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Returndatetime",
                table: "Cars",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Startdatetime",
                table: "Cars",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "BookingOrders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingOrders_AspNetUsers_ApplicationUserId",
                table: "BookingOrders",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingOrders_AspNetUsers_ApplicationUserId",
                table: "BookingOrders");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Displayorder",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Distance",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Returndatetime",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Startdatetime",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "BookingOrders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingOrders_AspNetUsers_ApplicationUserId",
                table: "BookingOrders",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
