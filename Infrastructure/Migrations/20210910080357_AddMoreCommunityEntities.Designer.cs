﻿// <auto-generated />
using System;
using FireplaceApi.Core.Models;
using FireplaceApi.Core.ValueObjects;
using FireplaceApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FireplaceApi.Infrastructure.Migrations
{
    [DbContext(typeof(FireplaceApiDbContext))]
    [Migration("20210910080357_AddMoreCommunityEntities")]
    partial class AddMoreCommunityEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.AccessTokenEntity", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("UserEntityId")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.HasIndex("Value")
                        .IsUnique();

                    b.ToTable("AccessTokenEntities");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.CommentEntity", b =>
                {
                    b.Property<long>("AuthorEntityId")
                        .HasColumnType("bigint");

                    b.Property<long>("PostEntityId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("Id")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Vote")
                        .HasColumnType("integer");

                    b.HasKey("AuthorEntityId", "PostEntityId");

                    b.HasIndex("AuthorEntityId")
                        .IsUnique();

                    b.HasIndex("PostEntityId")
                        .IsUnique();

                    b.ToTable("CommentEntities");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.CommentVoteEntity", b =>
                {
                    b.Property<long>("VoterEntityId")
                        .HasColumnType("bigint");

                    b.Property<long>("CommentEntityId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("Id")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsUp")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("VoterEntityId", "CommentEntityId");

                    b.HasIndex("CommentEntityId")
                        .IsUnique();

                    b.HasIndex("VoterEntityId")
                        .IsUnique();

                    b.ToTable("CommentVoteEntities");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.CommunityEntity", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("CreatorEntityId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatorEntityId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CommunityEntities");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.CommunityMemberEntity", b =>
                {
                    b.Property<long>("UserEntityId")
                        .HasColumnType("bigint");

                    b.Property<long>("CommunityEntityId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("UserEntityId", "CommunityEntityId");

                    b.HasIndex("CommunityEntityId")
                        .IsUnique();

                    b.HasIndex("UserEntityId")
                        .IsUnique();

                    b.ToTable("CommunityMemberEntities");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.EmailEntity", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ActivationCode")
                        .HasColumnType("integer");

                    b.Property<string>("ActivationStatus")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("UserEntityId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Address")
                        .IsUnique();

                    b.HasIndex("UserEntityId")
                        .IsUnique();

                    b.ToTable("EmailEntities");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.ErrorEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClientMessage")
                        .HasColumnType("text");

                    b.Property<int>("Code")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("HttpStatusCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(400);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("INTERNAL_SERVER");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ErrorEntities");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.FileEntity", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("RealName")
                        .HasColumnType("text");

                    b.Property<string>("RelativePhysicalPath")
                        .HasColumnType("text");

                    b.Property<string>("RelativeUri")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FileEntities");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.GlobalEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Configs>("Values")
                        .HasColumnType("jsonb")
                        .HasColumnName("Values");

                    b.HasKey("Id");

                    b.ToTable("GlobalEntities");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.GoogleUserEntity", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AccessToken")
                        .HasColumnType("text");

                    b.Property<long>("AccessTokenExpiresInSeconds")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("AccessTokenIssuedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("AuthUser")
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("GmailAddress")
                        .HasColumnType("text");

                    b.Property<long>("GmailIssuedTimeInSeconds")
                        .HasColumnType("bigint");

                    b.Property<bool>("GmailVerified")
                        .HasColumnType("boolean");

                    b.Property<string>("IdToken")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Locale")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("text");

                    b.Property<string>("Prompt")
                        .HasColumnType("text");

                    b.Property<string>("RedirectToUserUrl")
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<string>("Scope")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("TokenType")
                        .HasColumnType("text");

                    b.Property<long>("UserEntityId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GmailAddress")
                        .IsUnique();

                    b.HasIndex("UserEntityId")
                        .IsUnique();

                    b.ToTable("GoogleUserEntities");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.PostEntity", b =>
                {
                    b.Property<long>("AuthorEntityId")
                        .HasColumnType("bigint");

                    b.Property<long>("CommunityEntityId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("Id")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Vote")
                        .HasColumnType("integer");

                    b.HasKey("AuthorEntityId", "CommunityEntityId");

                    b.HasIndex("AuthorEntityId")
                        .IsUnique();

                    b.HasIndex("CommunityEntityId")
                        .IsUnique();

                    b.ToTable("PostEntities");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.PostVoteEntity", b =>
                {
                    b.Property<long>("VoterEntityId")
                        .HasColumnType("bigint");

                    b.Property<long>("PostEntityId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("Id")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsUp")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("VoterEntityId", "PostEntityId");

                    b.HasIndex("PostEntityId")
                        .IsUnique();

                    b.HasIndex("VoterEntityId")
                        .IsUnique();

                    b.ToTable("PostVoteEntities");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.SessionEntity", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("IpAddress")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<long>("UserEntityId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("SessionEntities");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.UserEntity", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("UserEntities");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.AccessTokenEntity", b =>
                {
                    b.HasOne("FireplaceApi.Infrastructure.Entities.UserEntity", "UserEntity")
                        .WithMany("AccessTokenEntities")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.CommentEntity", b =>
                {
                    b.HasOne("FireplaceApi.Infrastructure.Entities.UserEntity", "AuthorEntity")
                        .WithMany("CommentEntities")
                        .HasForeignKey("AuthorEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FireplaceApi.Infrastructure.Entities.PostEntity", "PostEntity")
                        .WithMany("CommentEntities")
                        .HasForeignKey("PostEntityId")
                        .HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthorEntity");

                    b.Navigation("PostEntity");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.CommentVoteEntity", b =>
                {
                    b.HasOne("FireplaceApi.Infrastructure.Entities.CommentEntity", "CommentEntity")
                        .WithMany("CommentVoteEntities")
                        .HasForeignKey("CommentEntityId")
                        .HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FireplaceApi.Infrastructure.Entities.UserEntity", "VoterEntity")
                        .WithMany("CommentVoteEntities")
                        .HasForeignKey("VoterEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommentEntity");

                    b.Navigation("VoterEntity");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.CommunityEntity", b =>
                {
                    b.HasOne("FireplaceApi.Infrastructure.Entities.UserEntity", "CreatorEntity")
                        .WithMany("OwnCommunities")
                        .HasForeignKey("CreatorEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatorEntity");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.CommunityMemberEntity", b =>
                {
                    b.HasOne("FireplaceApi.Infrastructure.Entities.CommunityEntity", "CommunityEntity")
                        .WithMany("CommunityMemberEntities")
                        .HasForeignKey("CommunityEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FireplaceApi.Infrastructure.Entities.UserEntity", "UserEntity")
                        .WithMany("JoinedCommunities")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommunityEntity");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.EmailEntity", b =>
                {
                    b.HasOne("FireplaceApi.Infrastructure.Entities.UserEntity", "UserEntity")
                        .WithOne("EmailEntity")
                        .HasForeignKey("FireplaceApi.Infrastructure.Entities.EmailEntity", "UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.GoogleUserEntity", b =>
                {
                    b.HasOne("FireplaceApi.Infrastructure.Entities.UserEntity", "UserEntity")
                        .WithOne("GoogleUserEntity")
                        .HasForeignKey("FireplaceApi.Infrastructure.Entities.GoogleUserEntity", "UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.PostEntity", b =>
                {
                    b.HasOne("FireplaceApi.Infrastructure.Entities.UserEntity", "AuthorEntity")
                        .WithMany("PostEntities")
                        .HasForeignKey("AuthorEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FireplaceApi.Infrastructure.Entities.CommunityEntity", "CommunityEntity")
                        .WithMany("PostEntities")
                        .HasForeignKey("CommunityEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthorEntity");

                    b.Navigation("CommunityEntity");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.PostVoteEntity", b =>
                {
                    b.HasOne("FireplaceApi.Infrastructure.Entities.PostEntity", "PostEntity")
                        .WithMany("PostVoteEntities")
                        .HasForeignKey("PostEntityId")
                        .HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FireplaceApi.Infrastructure.Entities.UserEntity", "VoterEntity")
                        .WithMany("PostVoteEntities")
                        .HasForeignKey("VoterEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PostEntity");

                    b.Navigation("VoterEntity");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.SessionEntity", b =>
                {
                    b.HasOne("FireplaceApi.Infrastructure.Entities.UserEntity", "UserEntity")
                        .WithMany("SessionEntities")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.CommentEntity", b =>
                {
                    b.Navigation("CommentVoteEntities");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.CommunityEntity", b =>
                {
                    b.Navigation("CommunityMemberEntities");

                    b.Navigation("PostEntities");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.PostEntity", b =>
                {
                    b.Navigation("CommentEntities");

                    b.Navigation("PostVoteEntities");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.UserEntity", b =>
                {
                    b.Navigation("AccessTokenEntities");

                    b.Navigation("CommentEntities");

                    b.Navigation("CommentVoteEntities");

                    b.Navigation("EmailEntity");

                    b.Navigation("GoogleUserEntity");

                    b.Navigation("JoinedCommunities");

                    b.Navigation("OwnCommunities");

                    b.Navigation("PostEntities");

                    b.Navigation("PostVoteEntities");

                    b.Navigation("SessionEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
