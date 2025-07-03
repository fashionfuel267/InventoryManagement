using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_LIB.Migrations
{
    /// <inheritdoc />
    public partial class br : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CompanyInfos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CompanyInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedIP",
                table: "CompanyInfos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CompanyInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CompanyInfos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CompanyInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedIP",
                table: "CompanyInfos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CompanyBranch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VatRegistryNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPersonDesignation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    CompanyInfoId = table.Column<int>(type: "int", nullable: false),
                    IsHeadOffice = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyBranch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyBranch_CompanyInfos_CompanyInfoId",
                        column: x => x.CompanyInfoId,
                        principalTable: "CompanyInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBranch_CompanyInfoId",
                table: "CompanyBranch",
                column: "CompanyInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyBranch");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CompanyInfos");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CompanyInfos");

            migrationBuilder.DropColumn(
                name: "CreatedIP",
                table: "CompanyInfos");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CompanyInfos");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CompanyInfos");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CompanyInfos");

            migrationBuilder.DropColumn(
                name: "ModifiedIP",
                table: "CompanyInfos");
        }
    }
}
