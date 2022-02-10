using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Store.Migrations
{
    public partial class added2column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "books",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "books");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "books");
        }
    }
}
