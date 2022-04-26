using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddingVisitIdIntoDoctorAssessment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAssessment_Visits_VisitId",
                table: "DoctorAssessment");

            migrationBuilder.AlterColumn<int>(
                name: "VisitId",
                table: "DoctorAssessment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAssessment_Visits_VisitId",
                table: "DoctorAssessment",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAssessment_Visits_VisitId",
                table: "DoctorAssessment");

            migrationBuilder.AlterColumn<int>(
                name: "VisitId",
                table: "DoctorAssessment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAssessment_Visits_VisitId",
                table: "DoctorAssessment",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
