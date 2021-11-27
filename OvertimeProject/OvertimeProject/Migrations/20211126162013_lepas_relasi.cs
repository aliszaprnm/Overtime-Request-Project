using Microsoft.EntityFrameworkCore.Migrations;

namespace OvertimeProject.Migrations
{
    public partial class lepas_relasi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_Employee_Tb_M_Employee_ManagerId",
                table: "Tb_M_Employee");

            migrationBuilder.DropIndex(
                name: "IX_Tb_M_Employee_ManagerId",
                table: "Tb_M_Employee");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerId",
                table: "Tb_M_Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ManagerId",
                table: "Tb_M_Employee",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_Employee_ManagerId",
                table: "Tb_M_Employee",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_M_Employee_Tb_M_Employee_ManagerId",
                table: "Tb_M_Employee",
                column: "ManagerId",
                principalTable: "Tb_M_Employee",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
