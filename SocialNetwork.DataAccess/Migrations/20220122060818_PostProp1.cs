using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class PostProp1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DutyDate",
                table: "Posts",
                newName: "TaskDate");

            migrationBuilder.AddColumn<string>(
                name: "CalendarJs",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalendarJs",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "TaskDate",
                table: "Posts",
                newName: "DutyDate");
        }
    }
}
