using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SWARocketChat.Data.Migrations
{
    public partial class UserRoomList1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRoomLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    ChatroomId = table.Column<Guid>(nullable: false),
                    ChatroomStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoomLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoomLists_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoomLists_Chatrooms_ChatroomId",
                        column: x => x.ChatroomId,
                        principalTable: "Chatrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoomLists_ApplicationUserId",
                table: "UserRoomLists",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoomLists_ChatroomId",
                table: "UserRoomLists",
                column: "ChatroomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoomLists");
        }
    }
}
