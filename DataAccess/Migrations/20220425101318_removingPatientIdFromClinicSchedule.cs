using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class removingPatientIdFromClinicSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
