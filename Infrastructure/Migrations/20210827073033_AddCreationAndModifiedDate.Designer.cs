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
    [Migration("20210827073033_AddCreationAndModifiedDate")]
    partial class AddCreationAndModifiedDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.UserInformationEntities.AccessTokenEntity", b =>
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

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.UserInformationEntities.EmailEntity", b =>
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

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.UserInformationEntities.GoogleUserEntity", b =>
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

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.UserInformationEntities.SessionEntity", b =>
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

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.UserInformationEntities.UserEntity", b =>
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

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.UserInformationEntities.AccessTokenEntity", b =>
                {
                    b.HasOne("FireplaceApi.Infrastructure.Entities.UserInformationEntities.UserEntity", "UserEntity")
                        .WithMany("AccessTokenEntities")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.UserInformationEntities.EmailEntity", b =>
                {
                    b.HasOne("FireplaceApi.Infrastructure.Entities.UserInformationEntities.UserEntity", "UserEntity")
                        .WithOne("EmailEntity")
                        .HasForeignKey("FireplaceApi.Infrastructure.Entities.UserInformationEntities.EmailEntity", "UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.UserInformationEntities.GoogleUserEntity", b =>
                {
                    b.HasOne("FireplaceApi.Infrastructure.Entities.UserInformationEntities.UserEntity", "UserEntity")
                        .WithOne("GoogleUserEntity")
                        .HasForeignKey("FireplaceApi.Infrastructure.Entities.UserInformationEntities.GoogleUserEntity", "UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.UserInformationEntities.SessionEntity", b =>
                {
                    b.HasOne("FireplaceApi.Infrastructure.Entities.UserInformationEntities.UserEntity", "UserEntity")
                        .WithMany("SessionEntities")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("FireplaceApi.Infrastructure.Entities.UserInformationEntities.UserEntity", b =>
                {
                    b.Navigation("AccessTokenEntities");

                    b.Navigation("EmailEntity");

                    b.Navigation("GoogleUserEntity");

                    b.Navigation("SessionEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
