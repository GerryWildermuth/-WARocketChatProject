using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SWARocketChat.Data.Migrations
{
    public partial class chatroommemberchanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chatrooms_ChatroomMembers_ChatroomMembersId",
                table: "Chatrooms");

            migrationBuilder.DropTable(
                name: "FriendList");

            migrationBuilder.DropIndex(
                name: "IX_Chatrooms_ChatroomMembersId",
                table: "Chatrooms");

            migrationBuilder.DropColumn(
                name: "ChatroomMembersId",
                table: "Chatrooms");

            migrationBuilder.AddColumn<Guid>(
                name: "ChatroomId",
                table: "ChatroomMembers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ChatroomMembers_ChatroomId",
                table: "ChatroomMembers",
                column: "ChatroomId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatroomMembers_Chatrooms_ChatroomId",
                table: "ChatroomMembers",
                column: "ChatroomId",
                principalTable: "Chatrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatroomMembers_Chatrooms_ChatroomId",
                table: "ChatroomMembers");

            migrationBuilder.DropIndex(
                name: "IX_ChatroomMembers_ChatroomId",
                table: "ChatroomMembers");

            migrationBuilder.DropColumn(
                name: "ChatroomId",
                table: "ChatroomMembers");

            migrationBuilder.AddColumn<Guid>(
                name: "ChatroomMembersId",
                table: "Chatrooms",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FriendList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendList_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chatrooms_ChatroomMembersId",
                table: "Chatrooms",
                column: "ChatroomMembersId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FriendList_UserId",
                table: "FriendList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendList_Username",
                table: "FriendList",
                column: "Username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Chatrooms_ChatroomMembers_ChatroomMembersId",
                table: "Chatrooms",
                column: "ChatroomMembersId",
                principalTable: "ChatroomMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
