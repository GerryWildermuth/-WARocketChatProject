using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SWARocketChat.Data.Migrations
{
    public partial class UserRoomList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserRoomListId",
                table: "Chatrooms",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserRoomLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ChatroomId = table.Column<Guid>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoomLists", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chatrooms_UserRoomListId",
                table: "Chatrooms",
                column: "UserRoomListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chatrooms_UserRoomLists_UserRoomListId",
                table: "Chatrooms",
                column: "UserRoomListId",
                principalTable: "UserRoomLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chatrooms_UserRoomLists_UserRoomListId",
                table: "Chatrooms");

            migrationBuilder.DropTable(
                name: "UserRoomLists");

            migrationBuilder.DropIndex(
                name: "IX_Chatrooms_UserRoomListId",
                table: "Chatrooms");

            migrationBuilder.DropColumn(
                name: "UserRoomListId",
                table: "Chatrooms");
        }
    }
}
