using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaStore.Storing.Migrations
{
    public partial class _2ndmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ToppingModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SizeModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Pizzas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CrustModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ToppingModel");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SizeModel");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CrustModel");
        }
    }
}
