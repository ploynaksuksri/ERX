﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Data;

namespace WebApi.Data.Migrations
{
    [DbContext(typeof(QuestionDbContext))]
    [Migration("20210720091857_Added_Participants")]
    partial class Added_Participants
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApi.Data.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChoiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("WrittenAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChoiceId");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("WebApi.Data.Models.Choice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("WebApi.Data.Models.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LastQuestionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LastQuestionId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("WebApi.Data.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("WebApi.Data.Models.Answer", b =>
                {
                    b.HasOne("WebApi.Data.Models.Choice", "Choice")
                        .WithMany()
                        .HasForeignKey("ChoiceId");

                    b.HasOne("WebApi.Data.Models.Participant", "Participant")
                        .WithMany("Answers")
                        .HasForeignKey("ParticipantId");

                    b.HasOne("WebApi.Data.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId");

                    b.Navigation("Choice");

                    b.Navigation("Participant");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("WebApi.Data.Models.Choice", b =>
                {
                    b.HasOne("WebApi.Data.Models.Question", "Question")
                        .WithMany("Choices")
                        .HasForeignKey("QuestionId");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("WebApi.Data.Models.Participant", b =>
                {
                    b.HasOne("WebApi.Data.Models.Question", "LastQuestion")
                        .WithMany()
                        .HasForeignKey("LastQuestionId");

                    b.Navigation("LastQuestion");
                });

            modelBuilder.Entity("WebApi.Data.Models.Participant", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("WebApi.Data.Models.Question", b =>
                {
                    b.Navigation("Choices");
                });
#pragma warning restore 612, 618
        }
    }
}
