using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddPatientIdIntoSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PatientId",
                table: "ClinicSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClinicSchedules_PatientId",
                table: "ClinicSchedules",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicSchedules_Patients_PatientId",
                table: "ClinicSchedules",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicSchedules_Patients_PatientId",
                table: "ClinicSchedules");

            migrationBuilder.DropIndex(
                name: "IX_ClinicSchedules_PatientId",
                table: "ClinicSchedules");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "ClinicSchedules");

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
    }
}
