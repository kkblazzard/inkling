using Microsoft.EntityFrameworkCore.Migrations;

namespace inkling.Migrations
{
    public partial class _4Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Approver_ApproverId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "rank",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "ApproverId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Approver_ApproverId",
                table: "Users",
                column: "ApproverId",
                principalTable: "Approver",
                principalColumn: "ApproverId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Approver_ApproverId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "ApproverId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "rank",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Approver_ApproverId",
                table: "Users",
                column: "ApproverId",
                principalTable: "Approver",
                principalColumn: "ApproverId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
