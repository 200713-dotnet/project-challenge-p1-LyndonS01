using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaStore.Storing.Migrations
{
    public partial class _4thmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_CrustModel_CrustId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_SizeModel_SizeId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_ToppingModel_Pizzas_PizzaModelId",
                table: "ToppingModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToppingModel",
                table: "ToppingModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SizeModel",
                table: "SizeModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CrustModel",
                table: "CrustModel");

            migrationBuilder.RenameTable(
                name: "ToppingModel",
                newName: "Toppings");

            migrationBuilder.RenameTable(
                name: "SizeModel",
                newName: "Sizes");

            migrationBuilder.RenameTable(
                name: "CrustModel",
                newName: "Crusts");

            migrationBuilder.RenameIndex(
                name: "IX_ToppingModel_PizzaModelId",
                table: "Toppings",
                newName: "IX_Toppings_PizzaModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crusts",
                table: "Crusts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Crusts_CrustId",
                table: "Pizzas",
                column: "CrustId",
                principalTable: "Crusts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sizes_SizeId",
                table: "Pizzas",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_Pizzas_PizzaModelId",
                table: "Toppings",
                column: "PizzaModelId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Crusts_CrustId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Sizes_SizeId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Pizzas_PizzaModelId",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crusts",
                table: "Crusts");

            migrationBuilder.RenameTable(
                name: "Toppings",
                newName: "ToppingModel");

            migrationBuilder.RenameTable(
                name: "Sizes",
                newName: "SizeModel");

            migrationBuilder.RenameTable(
                name: "Crusts",
                newName: "CrustModel");

            migrationBuilder.RenameIndex(
                name: "IX_Toppings_PizzaModelId",
                table: "ToppingModel",
                newName: "IX_ToppingModel_PizzaModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToppingModel",
                table: "ToppingModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SizeModel",
                table: "SizeModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CrustModel",
                table: "CrustModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_CrustModel_CrustId",
                table: "Pizzas",
                column: "CrustId",
                principalTable: "CrustModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_SizeModel_SizeId",
                table: "Pizzas",
                column: "SizeId",
                principalTable: "SizeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToppingModel_Pizzas_PizzaModelId",
                table: "ToppingModel",
                column: "PizzaModelId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
