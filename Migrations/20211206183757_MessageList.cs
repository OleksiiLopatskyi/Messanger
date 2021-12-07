using Microsoft.EntityFrameworkCore.Migrations;

namespace Message.Migrations
{
    public partial class MessageList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "FromId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromId",
                table: "Messages",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ToId",
                table: "Messages",
                column: "ToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_FromId",
                table: "Messages",
                column: "FromId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_ToId",
                table: "Messages",
                column: "ToId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_FromId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_ToId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_FromId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ToId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "FromId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ToId",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "To",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
