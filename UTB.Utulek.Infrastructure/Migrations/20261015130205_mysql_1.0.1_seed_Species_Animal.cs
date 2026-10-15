using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UTB.Utulek.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mysql_101_seed_Species_Animal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pes" },
                    { 2, "Kočka" },
                    { 3, "Králík" }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "BirthDate", "Breed", "Description", "Gender", "ImageFileName", "Name", "SpeciesId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kříženec", "Přátelský pes, má rád dlouhé procházky.", 0, "/img/animals/rex.jpg", "Rex", 1 },
                    { 2, new DateTime(2022, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evropská krátkosrstá", "Klidná kočka, vhodná i do bytu.", 1, "/img/animals/micka.jpg", "Micka", 2 },
                    { 3, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Králík domácí", "Mladý králík, zvyklý na děti.", 0, "/img/animals/bob.jpg", "Bob", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
