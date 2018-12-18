using Microsoft.EntityFrameworkCore.Migrations;

namespace inkling.Migrations
{
    public partial class _3Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_Approver_ApproverId",
                table: "Ideas");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "extra",
                table: "Results",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "extra2",
                table: "Results",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApproverId",
                table: "Ideas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Ideas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_Approver_ApproverId",
                table: "Ideas",
                column: "ApproverId",
                principalTable: "Approver",
                principalColumn: "ApproverId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_Approver_ApproverId",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "extra",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "extra2",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Ideas");

            migrationBuilder.AlterColumn<int>(
                name: "ApproverId",
                table: "Ideas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_Approver_ApproverId",
                table: "Ideas",
                column: "ApproverId",
                principalTable: "Approver",
                principalColumn: "ApproverId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
