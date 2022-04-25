﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddingPatientIdIntoClinicSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicSchedules_Patients_PatientId",
                table: "ClinicSchedules");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "ClinicSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicSchedules_Patients_PatientId",
                table: "ClinicSchedules",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicSchedules_Patients_PatientId",
                table: "ClinicSchedules");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "ClinicSchedules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
