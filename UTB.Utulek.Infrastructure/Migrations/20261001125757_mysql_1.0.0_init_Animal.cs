using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UTB.Utulek.Infrastructure.Migrations;

/// <inheritdoc />
public partial class mysql_100_init_Animal : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase()
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Species",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Species", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Animal",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Breed = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                Gender = table.Column<int>(type: "int", nullable: false),
                Description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ImageFileName = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                SpeciesId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Animal", x => x.Id);
                table.ForeignKey(
                    name: "FK_Animal_Species_SpeciesId",
                    column: x => x.SpeciesId,
                    principalTable: "Species",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "AnimalUpdate",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Title = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Text = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                AnimalId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AnimalUpdate", x => x.Id);
                table.ForeignKey(
                    name: "FK_AnimalUpdate_Animal_AnimalId",
                    column: x => x.AnimalId,
                    principalTable: "Animal",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "VirtualAdoption",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                MonthlyAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                Message = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                AnimalId = table.Column<int>(type: "int", nullable: false),
                UserId = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_VirtualAdoption", x => x.Id);
                table.ForeignKey(
                    name: "FK_VirtualAdoption_Animal_AnimalId",
                    column: x => x.AnimalId,
                    principalTable: "Animal",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateIndex(
            name: "IX_Animal_SpeciesId",
            table: "Animal",
            column: "SpeciesId");

        migrationBuilder.CreateIndex(
            name: "IX_AnimalUpdate_AnimalId",
            table: "AnimalUpdate",
            column: "AnimalId");

        migrationBuilder.CreateIndex(
            name: "IX_VirtualAdoption_AnimalId",
            table: "VirtualAdoption",
            column: "AnimalId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "AnimalUpdate");

        migrationBuilder.DropTable(
            name: "VirtualAdoption");

        migrationBuilder.DropTable(
            name: "Animal");

        migrationBuilder.DropTable(
            name: "Species");
    }
}
