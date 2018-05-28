using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SWARocketChat.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatroomMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    WritingPrivilege = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatroomMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chatrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ChatroomDesription = table.Column<string>(nullable: true),
                    ChatroomMembersId = table.Column<Guid>(nullable: true),
                    ChatroomName = table.Column<string>(nullable: false),
                    ChatroomTopic = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    MessageId = table.Column<Guid>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Private = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chatrooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chatrooms_ChatroomMembers_ChatroomMembersId",
                        column: x => x.ChatroomMembersId,
                        principalTable: "ChatroomMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ChatroomMembersId = table.Column<Guid>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    Password2 = table.Column<string>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    UserImage = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_ChatroomMembers_ChatroomMembersId",
                        column: x => x.ChatroomMembersId,
                        principalTable: "ChatroomMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FriendList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendList_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ChatroomId = table.Column<Guid>(nullable: true),
                    MessageString = table.Column<string>(nullable: false),
                    MessageTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Chatrooms_ChatroomId",
                        column: x => x.ChatroomId,
                        principalTable: "Chatrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chatrooms_ChatroomMembersId",
                table: "Chatrooms",
                column: "ChatroomMembersId");

            migrationBuilder.CreateIndex(
                name: "IX_Chatrooms_ChatroomName",
                table: "Chatrooms",
                column: "ChatroomName",
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

            migrationBuilder.CreateIndex(
                name: "IX_Message_ChatroomId",
                table: "Message",
                column: "ChatroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserId",
                table: "Message",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ChatroomMembersId",
                table: "Users",
                column: "ChatroomMembersId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendList");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Chatrooms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ChatroomMembers");
        }
    }
}
