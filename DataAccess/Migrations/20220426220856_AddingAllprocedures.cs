using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddingAllprocedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Visits_VisitId",
                table: "Procedures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Procedures",
                table: "Procedures");

            migrationBuilder.RenameTable(
                name: "Procedures",
                newName: "VisitProcedures");

            migrationBuilder.RenameIndex(
                name: "IX_Procedures_VisitId",
                table: "VisitProcedures",
                newName: "IX_VisitProcedures_VisitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VisitProcedures",
                table: "VisitProcedures",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AllProcedures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllProcedures", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_VisitProcedures_Visits_VisitId",
                table: "VisitProcedures",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitProcedures_Visits_VisitId",
                table: "VisitProcedures");

            migrationBuilder.DropTable(
                name: "AllProcedures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VisitProcedures",
                table: "VisitProcedures");

            migrationBuilder.RenameTable(
                name: "VisitProcedures",
                newName: "Procedures");

            migrationBuilder.RenameIndex(
                name: "IX_VisitProcedures_VisitId",
                table: "Procedures",
                newName: "IX_Procedures_VisitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Procedures",
                table: "Procedures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Visits_VisitId",
                table: "Procedures",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
