﻿// <auto-generated />
using System;
using GeneralInformationGame.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GeneralInformationGame.Shared.Migrations
{
    [DbContext(typeof(GameDbContext))]
    [Migration("20240205160312_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GameQuestion", b =>
                {
                    b.Property<int>("QuestionsId")
                        .HasColumnType("int");

                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.HasKey("QuestionsId", "GamesId");

                    b.HasIndex("GamesId");

                    b.ToTable("GameQuestion");
                });

            modelBuilder.Entity("GeneralInformationGame.Server.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GeneralInformationGame.Server.Models.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CorrectAnswers")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("IncorrectAnswers")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("GeneralInformationGame.Server.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TypeId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("GeneralInformationGame.Server.Models.QuestionCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuestionCategories");
                });

            modelBuilder.Entity("GeneralInformationGame.Server.Models.QuestionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuestionTypes");
                });

            modelBuilder.Entity("GameQuestion", b =>
                {
                    b.HasOne("GeneralInformationGame.Server.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeneralInformationGame.Server.Models.Question", null)
                        .WithMany()
                        .HasForeignKey("QuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GeneralInformationGame.Server.Models.Participant", b =>
                {
                    b.HasOne("GeneralInformationGame.Server.Models.Game", "Game")
                        .WithMany("Participants")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("GeneralInformationGame.Server.Models.Question", b =>
                {
                    b.HasOne("GeneralInformationGame.Server.Models.QuestionCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeneralInformationGame.Server.Models.QuestionType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("GeneralInformationGame.Server.Models.Game", b =>
                {
                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
