using Microsoft.EntityFrameworkCore.Migrations;

namespace OvertimeProject.Migrations
{
    public partial class update_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_T_UserRequest_Tb_M_Employee_EmployeeNIK",
                table: "Tb_T_UserRequest");

            migrationBuilder.DropIndex(
                name: "IX_Tb_T_UserRequest_EmployeeNIK",
                table: "Tb_T_UserRequest");

            migrationBuilder.DropColumn(
                name: "EmployeeNIK",
                table: "Tb_T_UserRequest");

            migrationBuilder.AlterColumn<string>(
                name: "NIK",
                table: "Tb_T_UserRequest",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_UserRequest_NIK",
                table: "Tb_T_UserRequest",
                column: "NIK");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_T_UserRequest_Tb_M_Employee_NIK",
                table: "Tb_T_UserRequest",
                column: "NIK",
                principalTable: "Tb_M_Employee",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_T_UserRequest_Tb_M_Employee_NIK",
                table: "Tb_T_UserRequest");

            migrationBuilder.DropIndex(
                name: "IX_Tb_T_UserRequest_NIK",
                table: "Tb_T_UserRequest");

            migrationBuilder.AlterColumn<string>(
                name: "NIK",
                table: "Tb_T_UserRequest",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeNIK",
                table: "Tb_T_UserRequest",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_UserRequest_EmployeeNIK",
                table: "Tb_T_UserRequest",
                column: "EmployeeNIK");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_T_UserRequest_Tb_M_Employee_EmployeeNIK",
                table: "Tb_T_UserRequest",
                column: "EmployeeNIK",
                principalTable: "Tb_M_Employee",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
