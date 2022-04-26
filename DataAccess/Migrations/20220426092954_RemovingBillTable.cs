using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class RemovingBillTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_PatientBills_PatientBillId",
                table: "Procedures");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_PatientBills_BillId",
                table: "Visits");

            migrationBuilder.DropTable(
                name: "PatientBills");

            migrationBuilder.DropIndex(
                name: "IX_Visits_BillId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "Visits");

            migrationBuilder.RenameColumn(
                name: "PatientBillId",
                table: "Procedures",
                newName: "VisitInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Procedures_PatientBillId",
                table: "Procedures",
                newName: "IX_Procedures_VisitInfoId");

            migrationBuilder.AddColumn<int>(
                name: "TotalAmout",
                table: "Visits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VisitAmout",
                table: "Visits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Visits_VisitInfoId",
                table: "Procedures",
                column: "VisitInfoId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Visits_VisitInfoId",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "TotalAmout",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "VisitAmout",
                table: "Visits");

            migrationBuilder.RenameColumn(
                name: "VisitInfoId",
                table: "Procedures",
                newName: "PatientBillId");

            migrationBuilder.RenameIndex(
                name: "IX_Procedures_VisitInfoId",
                table: "Procedures",
                newName: "IX_Procedures_PatientBillId");

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "Visits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PatientBills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAmout = table.Column<int>(type: "int", nullable: false),
                    VisitAmout = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientBills", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_BillId",
                table: "Visits",
                column: "BillId",
                unique: true,
                filter: "[BillId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_PatientBills_PatientBillId",
                table: "Procedures",
                column: "PatientBillId",
                principalTable: "PatientBills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
