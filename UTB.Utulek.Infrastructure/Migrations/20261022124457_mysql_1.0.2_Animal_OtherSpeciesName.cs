using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UTB.Utulek.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mysql_102_Animal_OtherSpeciesName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Species_SpeciesId",
                table: "Animal");

            migrationBuilder.AlterColumn<int>(
                name: "SpeciesId",
                table: "Animal",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "OtherSpeciesName",
                table: "Animal",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 1,
                column: "OtherSpeciesName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 2,
                column: "OtherSpeciesName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 3,
                column: "OtherSpeciesName",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Species_SpeciesId",
                table: "Animal",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Species_SpeciesId",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "OtherSpeciesName",
                table: "Animal");

            migrationBuilder.AlterColumn<int>(
                name: "SpeciesId",
                table: "Animal",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Species_SpeciesId",
                table: "Animal",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
