using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wineyard.Tools.Migrations
{
    /// <inheritdoc />
    public partial class fixrelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grapes_Wines_WineId",
                table: "Grapes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wines",
                table: "Wines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grapes",
                table: "Grapes");

            migrationBuilder.DropIndex(
                name: "IX_Grapes_WineId",
                table: "Grapes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Grapes");

            migrationBuilder.DropColumn(
                name: "WineId",
                table: "Grapes");

            migrationBuilder.AlterColumn<string>(
                name: "WineryName",
                table: "Wines",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Label",
                table: "Wines",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Wines",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Grapes",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wines",
                table: "Wines",
                columns: new[] { "WineryName", "Label" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grapes",
                table: "Grapes",
                column: "Name");

            migrationBuilder.CreateTable(
                name: "GrapeWine",
                columns: table => new
                {
                    GrapesName = table.Column<string>(type: "character varying(50)", nullable: false),
                    WinesWineryName = table.Column<string>(type: "character varying(50)", nullable: false),
                    WinesLabel = table.Column<string>(type: "character varying(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrapeWine", x => new { x.GrapesName, x.WinesWineryName, x.WinesLabel });
                    table.ForeignKey(
                        name: "FK_GrapeWine_Grapes_GrapesName",
                        column: x => x.GrapesName,
                        principalTable: "Grapes",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrapeWine_Wines_WinesWineryName_WinesLabel",
                        columns: x => new { x.WinesWineryName, x.WinesLabel },
                        principalTable: "Wines",
                        principalColumns: new[] { "WineryName", "Label" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrapeWine_WinesWineryName_WinesLabel",
                table: "GrapeWine",
                columns: new[] { "WinesWineryName", "WinesLabel" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrapeWine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wines",
                table: "Wines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grapes",
                table: "Grapes");

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Wines",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Label",
                table: "Wines",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "WineryName",
                table: "Wines",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Wines",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Grapes",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Grapes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "WineId",
                table: "Grapes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wines",
                table: "Wines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grapes",
                table: "Grapes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Grapes_WineId",
                table: "Grapes",
                column: "WineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grapes_Wines_WineId",
                table: "Grapes",
                column: "WineId",
                principalTable: "Wines",
                principalColumn: "Id");
        }
    }
}
