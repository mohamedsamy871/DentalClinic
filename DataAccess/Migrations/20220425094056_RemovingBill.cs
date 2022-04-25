using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class RemovingBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_PatientBills_PatientBillId",
                table: "Procedures");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_PatientBills_PatientBillId",
                table: "Visits");

            migrationBuilder.DropTable(
                name: "PatientBills");

            migrationBuilder.DropIndex(
                name: "IX_Visits_PatientBillId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Procedures_PatientBillId",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "PatientBillId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "PatientBillId",
                table: "Procedures");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientBillId",
                table: "Visits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientBillId",
                table: "Procedures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PatientBills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillTotalAmount = table.Column<int>(type: "int", nullable: false),
                    VisitPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientBills", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientBillId",
                table: "Visits",
                column: "PatientBillId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_PatientBillId",
                table: "Procedures",
                column: "PatientBillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_PatientBills_PatientBillId",
                table: "Procedures",
                column: "PatientBillId",
                principalTable: "PatientBills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_PatientBills_PatientBillId",
                table: "Visits",
                column: "PatientBillId",
                principalTable: "PatientBills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
