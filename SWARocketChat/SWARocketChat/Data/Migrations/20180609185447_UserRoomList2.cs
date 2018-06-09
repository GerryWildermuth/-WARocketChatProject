using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SWARocketChat.Data.Migrations
{
    public partial class UserRoomList2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserRoomLists",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserRoomListId",
                table: "AspNetUsers",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserRoomLists_UserRoomListId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserRoomListId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserRoomLists");

            migrationBuilder.DropColumn(
                name: "UserRoomListId",
                table: "AspNetUsers");
        }
    }
}
