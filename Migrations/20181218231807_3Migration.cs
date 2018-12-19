using Microsoft.EntityFrameworkCore.Migrations;

namespace inkling.Migrations
{
    public partial class _3Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApproverUserId",
                table: "Users",
                newName: "Rank");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rank",
                table: "Users",
                newName: "ApproverUserId");
        }
    }
}
