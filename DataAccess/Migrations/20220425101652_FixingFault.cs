using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class FixingFault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientBills_ClinicSchedules_ClinicScheduleId",
                table: "PatientBills");

            migrationBuilder.DropIndex(
                name: "IX_PatientBills_ClinicScheduleId",
                table: "PatientBills");

            migrationBuilder.DropColumn(
                name: "ClinicScheduleId",
                table: "PatientBills");

            migrationBuilder.AddColumn<int>(
                name: "ClinicScheduleId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ClinicScheduleId",
                table: "Patients",
                column: "ClinicScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_ClinicSchedules_ClinicScheduleId",
                table: "Patients",
                column: "ClinicScheduleId",
                principalTable: "ClinicSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_ClinicSchedules_ClinicScheduleId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_ClinicScheduleId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ClinicScheduleId",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "ClinicScheduleId",
                table: "PatientBills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientBills_ClinicScheduleId",
                table: "PatientBills",
                column: "ClinicScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientBills_ClinicSchedules_ClinicScheduleId",
                table: "PatientBills",
                column: "ClinicScheduleId",
                principalTable: "ClinicSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
