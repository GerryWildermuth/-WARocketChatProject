using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SWARocketChat.Data.Migrations
{
    public partial class RemoveFriendlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_FriendLists_FriendListId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FriendLists");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FriendListId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FriendListId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FriendListId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FriendLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserIdId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendLists_AspNetUsers_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FriendListId",
                table: "AspNetUsers",
                column: "FriendListId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendLists_UserIdId",
                table: "FriendLists",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_FriendLists_FriendListId",
                table: "AspNetUsers",
                column: "FriendListId",
                principalTable: "FriendLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
