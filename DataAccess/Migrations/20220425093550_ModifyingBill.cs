using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ModifyingBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_PatientBills_BillId",
                table: "Visits");

            migrationBuilder.RenameColumn(
                name: "BillId",
                table: "Visits",
                newName: "PatientBillId");

            migrationBuilder.RenameIndex(
                name: "IX_Visits_BillId",
                table: "Visits",
                newName: "IX_Visits_PatientBillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_PatientBills_PatientBillId",
                table: "Visits",
                column: "PatientBillId",
                principalTable: "PatientBills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_PatientBills_PatientBillId",
                table: "Visits");

            migrationBuilder.RenameColumn(
                name: "PatientBillId",
                table: "Visits",
                newName: "BillId");

            migrationBuilder.RenameIndex(
                name: "IX_Visits_PatientBillId",
                table: "Visits",
                newName: "IX_Visits_BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_PatientBills_BillId",
                table: "Visits",
                column: "BillId",
                principalTable: "PatientBills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
