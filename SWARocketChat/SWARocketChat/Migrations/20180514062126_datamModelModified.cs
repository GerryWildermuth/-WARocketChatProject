using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SWARocketChat.Migrations
{
    public partial class datamModelModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Chatrooms_ChatroomId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ChatroomId",
                table: "Users",
                newName: "ChatroomMembersId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ChatroomId",
                table: "Users",
                newName: "IX_Users_ChatroomMembersId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Chatrooms",
                newName: "MessageId");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ChatroomDesription",
                table: "Chatrooms",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChatroomMembersId",
                table: "Chatrooms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChatroomName",
                table: "Chatrooms",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChatroomTopic",
                table: "Chatrooms",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LogedIn",
                table: "Chatrooms",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Chatrooms",
                nullable: true);

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
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Chatrooms_ChatroomMembers_ChatroomMembersId",
                table: "Chatrooms",
                column: "ChatroomMembersId",
                principalTable: "ChatroomMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ChatroomMembers_ChatroomMembersId",
                table: "Users",
                column: "ChatroomMembersId",
                principalTable: "ChatroomMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chatrooms_ChatroomMembers_ChatroomMembersId",
                table: "Chatrooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_ChatroomMembers_ChatroomMembersId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ChatroomMembers");

            migrationBuilder.DropTable(
                name: "FriendList");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Username",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Chatrooms_ChatroomMembersId",
                table: "Chatrooms");

            migrationBuilder.DropIndex(
                name: "IX_Chatrooms_ChatroomName",
                table: "Chatrooms");

            migrationBuilder.DropColumn(
                name: "ChatroomDesription",
                table: "Chatrooms");

            migrationBuilder.DropColumn(
                name: "ChatroomMembersId",
                table: "Chatrooms");

            migrationBuilder.DropColumn(
                name: "ChatroomName",
                table: "Chatrooms");

            migrationBuilder.DropColumn(
                name: "ChatroomTopic",
                table: "Chatrooms");

            migrationBuilder.DropColumn(
                name: "LogedIn",
                table: "Chatrooms");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Chatrooms");

            migrationBuilder.RenameColumn(
                name: "ChatroomMembersId",
                table: "Users",
                newName: "ChatroomId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ChatroomMembersId",
                table: "Users",
                newName: "IX_Users_ChatroomId");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "Chatrooms",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Chatrooms_ChatroomId",
                table: "Users",
                column: "ChatroomId",
                principalTable: "Chatrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
