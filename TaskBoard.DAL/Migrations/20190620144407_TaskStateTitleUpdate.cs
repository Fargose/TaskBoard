using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskBoard.DAL.Migrations
{
    public partial class TaskStateTitleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskStaeTitle",
                table: "TaskStates",
                newName: "TaskStateTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskStateTitle",
                table: "TaskStates",
                newName: "TaskStaeTitle");
        }
    }
}
