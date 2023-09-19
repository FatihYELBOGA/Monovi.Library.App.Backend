﻿// <auto-generated />
using System;
using Library_App.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library_App.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20230919090948_abc")]
    partial class abc
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library_App.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookType")
                        .HasColumnType("int");

                    b.Property<int?>("ContentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageNumber")
                        .HasColumnType("int");

                    b.Property<int?>("PhotoId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("WriterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContentId")
                        .IsUnique()
                        .HasFilter("[ContentId] IS NOT NULL");

                    b.HasIndex("PhotoId")
                        .IsUnique()
                        .HasFilter("[PhotoId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.HasIndex("WriterId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library_App.Models.BookComments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookComments");
                });

            modelBuilder.Entity("Library_App.Models.BookRatings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookRatings");
                });

            modelBuilder.Entity("Library_App.Models.FavoriteBooks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("FavoriteBooks");
                });

            modelBuilder.Entity("Library_App.Models.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Library_App.Models.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Library_App.Models.SharingBooks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<int?>("ReceiverUserId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ReceiverUserId");

                    b.HasIndex("SenderUserId");

                    b.ToTable("SharingBooks");
                });

            modelBuilder.Entity("Library_App.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BornDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfilId")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfilId")
                        .IsUnique()
                        .HasFilter("[ProfilId] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Library_App.Models.UserFriends", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FriendOneId")
                        .HasColumnType("int");

                    b.Property<int?>("FriendTwoId")
                        .HasColumnType("int");

                    b.Property<int>("RequestStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FriendOneId");

                    b.HasIndex("FriendTwoId");

                    b.ToTable("UserFriends");
                });

            modelBuilder.Entity("Library_App.Models.Writer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nationality")
                        .HasColumnType("int");

                    b.Property<int?>("ProfilId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfilId")
                        .IsUnique()
                        .HasFilter("[ProfilId] IS NOT NULL");

                    b.ToTable("Writers");
                });

            modelBuilder.Entity("Library_App.Models.Book", b =>
                {
                    b.HasOne("Library_App.Models.File", "Content")
                        .WithOne("BookContent")
                        .HasForeignKey("Library_App.Models.Book", "ContentId");

                    b.HasOne("Library_App.Models.File", "Photo")
                        .WithOne("Book")
                        .HasForeignKey("Library_App.Models.Book", "PhotoId");

                    b.HasOne("Library_App.Models.User", "User")
                        .WithMany("Books")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Library_App.Models.Writer", "Writer")
                        .WithMany("Books")
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Content");

                    b.Navigation("Photo");

                    b.Navigation("User");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("Library_App.Models.BookComments", b =>
                {
                    b.HasOne("Library_App.Models.Book", "Book")
                        .WithMany("BookComments")
                        .HasForeignKey("BookId");

                    b.HasOne("Library_App.Models.User", "User")
                        .WithMany("BookComments")
                        .HasForeignKey("UserId");

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Library_App.Models.BookRatings", b =>
                {
                    b.HasOne("Library_App.Models.Book", "Book")
                        .WithMany("BookRatings")
                        .HasForeignKey("BookId");

                    b.HasOne("Library_App.Models.User", "User")
                        .WithMany("BookRatings")
                        .HasForeignKey("UserId");

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Library_App.Models.FavoriteBooks", b =>
                {
                    b.HasOne("Library_App.Models.Book", "Book")
                        .WithMany("FavoriteBooks")
                        .HasForeignKey("BookId");

                    b.HasOne("Library_App.Models.User", "User")
                        .WithMany("FavoriteBooks")
                        .HasForeignKey("UserId");

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Library_App.Models.RefreshToken", b =>
                {
                    b.HasOne("Library_App.Models.User", "User")
                        .WithOne("RefreshToken")
                        .HasForeignKey("Library_App.Models.RefreshToken", "UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Library_App.Models.SharingBooks", b =>
                {
                    b.HasOne("Library_App.Models.Book", "Book")
                        .WithMany("SharingBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Library_App.Models.User", "ReceiverUser")
                        .WithMany("ReceiverBooks")
                        .HasForeignKey("ReceiverUserId");

                    b.HasOne("Library_App.Models.User", "SenderUser")
                        .WithMany("SenderBooks")
                        .HasForeignKey("SenderUserId");

                    b.Navigation("Book");

                    b.Navigation("ReceiverUser");

                    b.Navigation("SenderUser");
                });

            modelBuilder.Entity("Library_App.Models.User", b =>
                {
                    b.HasOne("Library_App.Models.File", "Profil")
                        .WithOne("User")
                        .HasForeignKey("Library_App.Models.User", "ProfilId");

                    b.Navigation("Profil");
                });

            modelBuilder.Entity("Library_App.Models.UserFriends", b =>
                {
                    b.HasOne("Library_App.Models.User", "FriendOne")
                        .WithMany("UserFriendsOne")
                        .HasForeignKey("FriendOneId");

                    b.HasOne("Library_App.Models.User", "FriendTwo")
                        .WithMany("UserFriendsTwo")
                        .HasForeignKey("FriendTwoId");

                    b.Navigation("FriendOne");

                    b.Navigation("FriendTwo");
                });

            modelBuilder.Entity("Library_App.Models.Writer", b =>
                {
                    b.HasOne("Library_App.Models.File", "Profil")
                        .WithOne("Writer")
                        .HasForeignKey("Library_App.Models.Writer", "ProfilId");

                    b.Navigation("Profil");
                });

            modelBuilder.Entity("Library_App.Models.Book", b =>
                {
                    b.Navigation("BookComments");

                    b.Navigation("BookRatings");

                    b.Navigation("FavoriteBooks");

                    b.Navigation("SharingBooks");
                });

            modelBuilder.Entity("Library_App.Models.File", b =>
                {
                    b.Navigation("Book");

                    b.Navigation("BookContent");

                    b.Navigation("User");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("Library_App.Models.User", b =>
                {
                    b.Navigation("BookComments");

                    b.Navigation("BookRatings");

                    b.Navigation("Books");

                    b.Navigation("FavoriteBooks");

                    b.Navigation("ReceiverBooks");

                    b.Navigation("RefreshToken");

                    b.Navigation("SenderBooks");

                    b.Navigation("UserFriendsOne");

                    b.Navigation("UserFriendsTwo");
                });

            modelBuilder.Entity("Library_App.Models.Writer", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
