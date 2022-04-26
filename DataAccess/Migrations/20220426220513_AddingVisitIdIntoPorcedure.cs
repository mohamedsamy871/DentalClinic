using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddingVisitIdIntoPorcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Visits_VisitInfoId",
                table: "Procedures");

            migrationBuilder.DropIndex(
                name: "IX_Procedures_VisitInfoId",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "VisitInfoId",
                table: "Procedures");

            migrationBuilder.AddColumn<int>(
                name: "VisitId",
                table: "Procedures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_VisitId",
                table: "Procedures",
                column: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Visits_VisitId",
                table: "Procedures",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Visits_VisitId",
                table: "Procedures");

            migrationBuilder.DropIndex(
                name: "IX_Procedures_VisitId",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "Procedures");

            migrationBuilder.AddColumn<int>(
                name: "VisitInfoId",
                table: "Procedures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_VisitInfoId",
                table: "Procedures",
                column: "VisitInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Visits_VisitInfoId",
                table: "Procedures",
                column: "VisitInfoId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
