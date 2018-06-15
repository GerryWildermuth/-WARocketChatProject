using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SWARocketChat.Data.Migrations
{
    public partial class additionalModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "AspNetUsers",
                newName: "UserImage");

            migrationBuilder.AddColumn<Guid>(
                name: "ChatroomMembersId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: (byte)0);

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
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ChatroomId = table.Column<Guid>(nullable: true),
                    MessageString = table.Column<string>(nullable: false),
                    MessageTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
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
                        name: "FK_Message_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ChatroomMembersId",
                table: "AspNetUsers",
                column: "ChatroomMembersId");

            migrationBuilder.CreateIndex(
                name: "IX_Chatrooms_ChatroomMembersId",
                table: "Chatrooms",
                column: "ChatroomMembersId",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ChatroomMembers_ChatroomMembersId",
                table: "AspNetUsers",
                column: "ChatroomMembersId",
                principalTable: "ChatroomMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ChatroomMembers_ChatroomMembersId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FriendList");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Chatrooms");

            migrationBuilder.DropTable(
                name: "ChatroomMembers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ChatroomMembersId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ChatroomMembersId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserImage",
                table: "AspNetUsers",
                newName: "State");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
