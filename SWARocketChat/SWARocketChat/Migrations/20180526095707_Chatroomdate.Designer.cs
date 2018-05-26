﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SWARocketChat.Models;
using System;

namespace SWARocketChat.Migrations
{
    [DbContext(typeof(RocketChatContext))]
    [Migration("20180526095707_Chatroomdate")]
    partial class Chatroomdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("SWARocketChat.Models.Chatroom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ChatroomDesription");

                    b.Property<Guid?>("ChatroomMembersId");

                    b.Property<string>("ChatroomName")
                        .IsRequired();

                    b.Property<string>("ChatroomTopic");

                    b.Property<DateTime>("CreationDate");

                    b.Property<Guid>("MessageId");

                    b.Property<string>("Password");

                    b.Property<bool>("Private");

                    b.HasKey("Id");

                    b.HasIndex("ChatroomMembersId");

                    b.HasIndex("ChatroomName")
                        .IsUnique();

                    b.ToTable("Chatrooms");
                });

            modelBuilder.Entity("SWARocketChat.Models.ChatroomMembers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("UserId");

                    b.Property<bool>("WritingPrivilege");

                    b.HasKey("Id");

                    b.ToTable("ChatroomMembers");
                });

            modelBuilder.Entity("SWARocketChat.Models.FriendList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("UserId");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("FriendList");
                });

            modelBuilder.Entity("SWARocketChat.Models.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ChatroomId");

                    b.Property<string>("MessageString")
                        .IsRequired();

                    b.Property<DateTime>("MessageTime");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ChatroomId");

                    b.HasIndex("UserId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("SWARocketChat.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ChatroomMembersId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<byte>("Status");

                    b.Property<string>("UserImage");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ChatroomMembersId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SWARocketChat.Models.Chatroom", b =>
                {
                    b.HasOne("SWARocketChat.Models.ChatroomMembers", "ChatroomMembers")
                        .WithMany()
                        .HasForeignKey("ChatroomMembersId");
                });

            modelBuilder.Entity("SWARocketChat.Models.FriendList", b =>
                {
                    b.HasOne("SWARocketChat.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SWARocketChat.Models.Message", b =>
                {
                    b.HasOne("SWARocketChat.Models.Chatroom")
                        .WithMany("Messages")
                        .HasForeignKey("ChatroomId");

                    b.HasOne("SWARocketChat.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SWARocketChat.Models.User", b =>
                {
                    b.HasOne("SWARocketChat.Models.ChatroomMembers")
                        .WithMany("Users")
                        .HasForeignKey("ChatroomMembersId");
                });
#pragma warning restore 612, 618
        }
    }
}
