using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Response.Migrations
{
    public partial class AddInformationComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Emotion",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "Grade",
                table: "Comments",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Emotion",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Comments");
        }
    }
}
