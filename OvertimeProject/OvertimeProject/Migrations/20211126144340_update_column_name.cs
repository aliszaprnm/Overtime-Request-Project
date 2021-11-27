using Microsoft.EntityFrameworkCore.Migrations;

namespace OvertimeProject.Migrations
{
    public partial class update_column_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_T_Account_Tb_M_Employee_NIK",
                table: "Tb_T_Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_T_AccountRole_Tb_T_Account_AccountNIK",
                table: "Tb_T_AccountRole");

            migrationBuilder.DropIndex(
                name: "IX_Tb_T_AccountRole_AccountNIK",
                table: "Tb_T_AccountRole");

            migrationBuilder.DropColumn(
                name: "AccountNIK",
                table: "Tb_T_AccountRole");

            migrationBuilder.DropColumn(
                name: "NIK",
                table: "Tb_T_AccountRole");

            migrationBuilder.RenameColumn(
                name: "NIK",
                table: "Tb_T_Account",
                newName: "AccountId");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Tb_T_AccountRole",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_AccountRole_AccountId",
                table: "Tb_T_AccountRole",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_T_Account_Tb_M_Employee_AccountId",
                table: "Tb_T_Account",
                column: "AccountId",
                principalTable: "Tb_M_Employee",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_T_AccountRole_Tb_T_Account_AccountId",
                table: "Tb_T_AccountRole",
                column: "AccountId",
                principalTable: "Tb_T_Account",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_T_Account_Tb_M_Employee_AccountId",
                table: "Tb_T_Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_T_AccountRole_Tb_T_Account_AccountId",
                table: "Tb_T_AccountRole");

            migrationBuilder.DropIndex(
                name: "IX_Tb_T_AccountRole_AccountId",
                table: "Tb_T_AccountRole");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Tb_T_AccountRole");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Tb_T_Account",
                newName: "NIK");

            migrationBuilder.AddColumn<string>(
                name: "AccountNIK",
                table: "Tb_T_AccountRole",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NIK",
                table: "Tb_T_AccountRole",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_AccountRole_AccountNIK",
                table: "Tb_T_AccountRole",
                column: "AccountNIK");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_T_Account_Tb_M_Employee_NIK",
                table: "Tb_T_Account",
                column: "NIK",
                principalTable: "Tb_M_Employee",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_T_AccountRole_Tb_T_Account_AccountNIK",
                table: "Tb_T_AccountRole",
                column: "AccountNIK",
                principalTable: "Tb_T_Account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
