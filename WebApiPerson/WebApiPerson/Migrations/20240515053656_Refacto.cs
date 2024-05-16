using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiPerson.Migrations
{
    /// <inheritdoc />
    public partial class Refacto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Persons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Persons",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "Persons",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDay",
                table: "Persons",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "CivilStatus",
                table: "Persons",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerType",
                table: "Persons",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Persons",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Persons",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentificationNumber",
                table: "Persons",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Persons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Persons",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Persons",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "Persons",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CivilStatus",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CustomerType",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "IdentificationNumber",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Profession",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Persons",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
