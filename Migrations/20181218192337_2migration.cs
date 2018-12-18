using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace inkling.Migrations
{
    public partial class _2migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApproverId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdeaId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "rank",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Approver",
                columns: table => new
                {
                    ApproverId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    IdeaId = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approver", x => x.ApproverId);
                });

            migrationBuilder.CreateTable(
                name: "Edd",
                columns: table => new
                {
                    EddId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Eddlink = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edd", x => x.EddId);
                });

            migrationBuilder.CreateTable(
                name: "Ideas",
                columns: table => new
                {
                    IdeaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    desc = table.Column<string>(nullable: false),
                    EddId = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    ApproverId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideas", x => x.IdeaId);
                    table.ForeignKey(
                        name: "FK_Ideas_Approver_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "Approver",
                        principalColumn: "ApproverId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ResultId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    result = table.Column<string>(nullable: false),
                    EddId1 = table.Column<int>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.ResultId);
                    table.ForeignKey(
                        name: "FK_Results_Edd_EddId1",
                        column: x => x.EddId1,
                        principalTable: "Edd",
                        principalColumn: "EddId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    IdeaId = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Department_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "IdeaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Department_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MessageId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    message = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    IdeaId = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Message_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "IdeaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Message_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ApproverId",
                table: "Users",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdeaId",
                table: "Users",
                column: "IdeaId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_IdeaId",
                table: "Department",
                column: "IdeaId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_UserId",
                table: "Department",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_ApproverId",
                table: "Ideas",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_IdeaId",
                table: "Message",
                column: "IdeaId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserId",
                table: "Message",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_EddId1",
                table: "Results",
                column: "EddId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Approver_ApproverId",
                table: "Users",
                column: "ApproverId",
                principalTable: "Approver",
                principalColumn: "ApproverId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Ideas_IdeaId",
                table: "Users",
                column: "IdeaId",
                principalTable: "Ideas",
                principalColumn: "IdeaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Approver_ApproverId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Ideas_IdeaId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Ideas");

            migrationBuilder.DropTable(
                name: "Edd");

            migrationBuilder.DropTable(
                name: "Approver");

            migrationBuilder.DropIndex(
                name: "IX_Users_ApproverId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdeaId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ApproverId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdeaId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "rank",
                table: "Users");
        }
    }
}
