using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CsvAnalyzer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFileEntryIdToResultsEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "results");

            migrationBuilder.AddColumn<Guid>(
                name: "FileEntryId",
                table: "results",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_results_FileEntryId",
                table: "results",
                column: "FileEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_results_files_FileEntryId",
                table: "results",
                column: "FileEntryId",
                principalTable: "files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_results_files_FileEntryId",
                table: "results");

            migrationBuilder.DropIndex(
                name: "IX_results_FileEntryId",
                table: "results");

            migrationBuilder.DropColumn(
                name: "FileEntryId",
                table: "results");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "results",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
