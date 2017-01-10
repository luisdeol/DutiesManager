using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DutiesManager_RESTfulAPI.Migrations
{
    public partial class AddDueDateAndChangeDueTimeToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DueTime",
                table: "Duties",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Duties",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Duties");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueTime",
                table: "Duties",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
