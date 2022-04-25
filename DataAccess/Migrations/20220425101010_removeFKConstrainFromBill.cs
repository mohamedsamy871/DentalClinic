using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class removeFKConstrainFromBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientBills_Visits_VisitId",
                table: "PatientBills");

            migrationBuilder.DropIndex(
                name: "IX_Visits_BillId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_PatientBills_VisitId",
                table: "PatientBills");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "PatientBills");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_BillId",
                table: "Visits",
                column: "BillId",
                unique: true,
                filter: "[BillId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Visits_BillId",
                table: "Visits");

            migrationBuilder.AddColumn<int>(
                name: "VisitId",
                table: "PatientBills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_BillId",
                table: "Visits",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientBills_VisitId",
                table: "PatientBills",
                column: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientBills_Visits_VisitId",
                table: "PatientBills",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
