using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SWARocketChat.Data.Migrations
{
    public partial class UserRoomList3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserRoomLists_UserRoomListId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Chatrooms_UserRoomLists_UserRoomListId",
                table: "Chatrooms");

            migrationBuilder.DropIndex(
                name: "IX_Chatrooms_UserRoomListId",
                table: "Chatrooms");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserRoomListId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserRoomListId",
                table: "Chatrooms");

            migrationBuilder.DropColumn(
                name: "UserRoomListId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "UserRoomLists",
                newName: "ChatroomStatus");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserRoomLists",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChatroomId",
                table: "UserRoomLists",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserRoomLists_ApplicationUserId",
                table: "UserRoomLists",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoomLists_ChatroomId",
                table: "UserRoomLists",
                column: "ChatroomId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoomLists_AspNetUsers_ApplicationUserId",
                table: "UserRoomLists",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoomLists_Chatrooms_ChatroomId",
                table: "UserRoomLists",
                column: "ChatroomId",
                principalTable: "Chatrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoomLists_AspNetUsers_ApplicationUserId",
                table: "UserRoomLists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoomLists_Chatrooms_ChatroomId",
                table: "UserRoomLists");

            migrationBuilder.DropIndex(
                name: "IX_UserRoomLists_ApplicationUserId",
                table: "UserRoomLists");

            migrationBuilder.DropIndex(
                name: "IX_UserRoomLists_ChatroomId",
                table: "UserRoomLists");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserRoomLists");

            migrationBuilder.DropColumn(
                name: "ChatroomId",
                table: "UserRoomLists");

            migrationBuilder.RenameColumn(
                name: "ChatroomStatus",
                table: "UserRoomLists",
                newName: "status");

            migrationBuilder.AddColumn<Guid>(
                name: "UserRoomListId",
                table: "Chatrooms",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserRoomListId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chatrooms_UserRoomListId",
                table: "Chatrooms",
                column: "UserRoomListId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserRoomListId",
                table: "AspNetUsers",
                column: "UserRoomListId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserRoomLists_UserRoomListId",
                table: "AspNetUsers",
                column: "UserRoomListId",
                principalTable: "UserRoomLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chatrooms_UserRoomLists_UserRoomListId",
                table: "Chatrooms",
                column: "UserRoomListId",
                principalTable: "UserRoomLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
