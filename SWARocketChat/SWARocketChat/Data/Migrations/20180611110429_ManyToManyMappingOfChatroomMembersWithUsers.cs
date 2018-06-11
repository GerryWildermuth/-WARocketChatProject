using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SWARocketChat.Data.Migrations
{
    public partial class ManyToManyMappingOfChatroomMembersWithUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ChatroomMembers_ChatroomMembersId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ChatroomMembersId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ChatroomMembersId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "UserChatroomMember",
                columns: table => new
                {
                    ChatroomMembersId = table.Column<Guid>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChatroomMember", x => new { x.ChatroomMembersId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_UserChatroomMember_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserChatroomMember_ChatroomMembers_ChatroomMembersId",
                        column: x => x.ChatroomMembersId,
                        principalTable: "ChatroomMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserChatroomMember_ApplicationUserId",
                table: "UserChatroomMember",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserChatroomMember");

            migrationBuilder.AddColumn<Guid>(
                name: "ChatroomMembersId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ChatroomMembersId",
                table: "AspNetUsers",
                column: "ChatroomMembersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ChatroomMembers_ChatroomMembersId",
                table: "AspNetUsers",
                column: "ChatroomMembersId",
                principalTable: "ChatroomMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
