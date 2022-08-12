using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Response.Migrations
{
    public partial class AddReferenceCommentActor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActorId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ActorId",
                table: "Comments",
                column: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Actors_ActorId",
                table: "Comments",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Actors_ActorId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ActorId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "Comments");
        }
    }
}
