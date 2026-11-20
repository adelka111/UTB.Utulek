using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UTB.Utulek.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mysql_110_user_navigation_and_seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28308a6d-0b6b-42be-9bd0-3353de6fedd5", "9cadda5d-6111-47c1-8578-12995cfc8e37", "Manager", "MANAGER" },
                    { "5eb05733-a760-4701-b023-3a4320286069", "7970aed5-0ade-4c89-b9e7-47e72341657f", "Admin", "ADMIN" },
                    { "cad2816b-23b6-476b-9a57-2873678dddf0", "0f5325cd-bf71-49e7-9c50-f9d93cd73737", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cfe1b584-c967-4c7f-81b2-89f8db220194", 0, "02bedc5f-d351-4465-9e60-b4a9d71144eb", "admin@utulek.cz", true, "Administrátor", true, null, "ADMIN@UTULEK.CZ", "ADMIN@UTULEK.CZ", "AQAAAAIAAYagAAAAEPjzRiWsnOQ9PXKLHwVKLCOz37SXhsmU1BIAX+gzYDF+4NEQSei8xVi5Iipv0gChyg==", null, false, "46324865-59f9-4aec-a4f7-383ded4e7391", false, "admin@utulek.cz" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "28308a6d-0b6b-42be-9bd0-3353de6fedd5", "cfe1b584-c967-4c7f-81b2-89f8db220194" },
                    { "5eb05733-a760-4701-b023-3a4320286069", "cfe1b584-c967-4c7f-81b2-89f8db220194" },
                    { "cad2816b-23b6-476b-9a57-2873678dddf0", "cfe1b584-c967-4c7f-81b2-89f8db220194" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "28308a6d-0b6b-42be-9bd0-3353de6fedd5", "cfe1b584-c967-4c7f-81b2-89f8db220194" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5eb05733-a760-4701-b023-3a4320286069", "cfe1b584-c967-4c7f-81b2-89f8db220194" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cad2816b-23b6-476b-9a57-2873678dddf0", "cfe1b584-c967-4c7f-81b2-89f8db220194" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28308a6d-0b6b-42be-9bd0-3353de6fedd5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5eb05733-a760-4701-b023-3a4320286069");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cad2816b-23b6-476b-9a57-2873678dddf0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfe1b584-c967-4c7f-81b2-89f8db220194");
        }
    }
}
