using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_LIB.Migrations
{
    /// <inheritdoc />
    public partial class br3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranch_CompanyInfos_CompanyInfoId",
                table: "CompanyBranch");

            migrationBuilder.DropIndex(
                name: "IX_CompanyBranch_CompanyInfoId",
                table: "CompanyBranch");

            migrationBuilder.DropColumn(
                name: "CompanyInfoId",
                table: "CompanyBranch");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBranch_ComId",
                table: "CompanyBranch",
                column: "ComId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBranch_CompanyInfos_ComId",
                table: "CompanyBranch",
                column: "ComId",
                principalTable: "CompanyInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranch_CompanyInfos_ComId",
                table: "CompanyBranch");

            migrationBuilder.DropIndex(
                name: "IX_CompanyBranch_ComId",
                table: "CompanyBranch");

            migrationBuilder.AddColumn<int>(
                name: "CompanyInfoId",
                table: "CompanyBranch",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBranch_CompanyInfoId",
                table: "CompanyBranch",
                column: "CompanyInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBranch_CompanyInfos_CompanyInfoId",
                table: "CompanyBranch",
                column: "CompanyInfoId",
                principalTable: "CompanyInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
