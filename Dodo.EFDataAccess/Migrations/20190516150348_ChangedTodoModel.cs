using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dodo.EFDataAccess.Migrations
{
    public partial class ChangedTodoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Todos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Todos",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "CreatedDate" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2019, 5, 16, 18, 3, 48, 283, DateTimeKind.Unspecified).AddTicks(7990), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "CreatedDate" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2019, 5, 16, 18, 3, 48, 285, DateTimeKind.Unspecified).AddTicks(2718), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "CreatedDate" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2019, 5, 16, 18, 3, 48, 285, DateTimeKind.Unspecified).AddTicks(2740), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "CreatedDate" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2019, 5, 16, 18, 3, 48, 285, DateTimeKind.Unspecified).AddTicks(2746), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Todos");
        }
    }
}
