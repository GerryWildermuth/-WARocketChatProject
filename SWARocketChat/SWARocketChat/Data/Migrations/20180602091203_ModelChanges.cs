using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SWARocketChat.Data.Migrations
{
    public partial class ModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Chatrooms_ChatroomId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "ChatroomMembesId",
                table: "Chatrooms");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "Chatrooms");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChatroomId",
                table: "Message",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Chatrooms_ChatroomId",
                table: "Message",
                column: "ChatroomId",
                principalTable: "Chatrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Chatrooms_ChatroomId",
                table: "Message");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChatroomId",
                table: "Message",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "ChatroomMembesId",
                table: "Chatrooms",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MessageId",
                table: "Chatrooms",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Chatrooms_ChatroomId",
                table: "Message",
                column: "ChatroomId",
                principalTable: "Chatrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
