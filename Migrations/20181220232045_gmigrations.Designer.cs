﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using inkling.Models;

namespace inkling.Migrations
{
    [DbContext(typeof(InklingContext))]
    [Migration("20181220232045_gmigrations")]
    partial class gmigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("inkling.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdeaId");

                    b.Property<int>("UserId");

                    b.Property<DateTime>("created_at");

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<DateTime>("updated_at");

                    b.HasKey("DepartmentId");

                    b.HasIndex("IdeaId");

                    b.HasIndex("UserId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("inkling.Models.Experiment", b =>
                {
                    b.Property<int>("ExperimentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ExperimentDesc")
                        .IsRequired();

                    b.Property<int>("IdeaId");

                    b.Property<string>("Result");

                    b.Property<int>("Score");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("ExperimentId");

                    b.HasIndex("IdeaId");

                    b.ToTable("Experiment");
                });

            modelBuilder.Entity("inkling.Models.Idea", b =>
                {
                    b.Property<int>("IdeaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApproverId");

                    b.Property<int>("ApproverRank0");

                    b.Property<int>("ApproverRank1");

                    b.Property<int>("ApproverRank2");

                    b.Property<int>("ApproverRank3");

                    b.Property<int>("ApproverRank4");

                    b.Property<int>("ApproverRank5");

                    b.Property<int>("CreatorId");

                    b.Property<int?>("UserId");

                    b.Property<DateTime>("created_at");

                    b.Property<string>("desc")
                        .IsRequired();

                    b.Property<string>("fiveAD");

                    b.Property<string>("fourAD");

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<string>("oneAD");

                    b.Property<string>("threeAD");

                    b.Property<string>("twoAD");

                    b.Property<DateTime>("updated_at");

                    b.Property<string>("zeroAD");

                    b.HasKey("IdeaId");

                    b.HasIndex("UserId");

                    b.ToTable("Ideas");
                });

            modelBuilder.Entity("inkling.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdeaId");

                    b.Property<int>("UserId");

                    b.Property<DateTime>("created_at");

                    b.Property<string>("message")
                        .IsRequired();

                    b.Property<DateTime>("updated_at");

                    b.HasKey("MessageId");

                    b.HasIndex("IdeaId");

                    b.HasIndex("UserId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("inkling.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("IdeaId");

                    b.Property<int>("Rank");

                    b.Property<DateTime>("created_at");

                    b.Property<int>("departId");

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("fname")
                        .IsRequired();

                    b.Property<string>("lname")
                        .IsRequired();

                    b.Property<string>("password")
                        .IsRequired();

                    b.Property<DateTime>("updated_at");

                    b.HasKey("UserId");

                    b.HasIndex("IdeaId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("inkling.Models.Department", b =>
                {
                    b.HasOne("inkling.Models.Idea", "Idea")
                        .WithMany("Departments")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("inkling.Models.User", "User")
                        .WithMany("department")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("inkling.Models.Experiment", b =>
                {
                    b.HasOne("inkling.Models.Idea")
                        .WithMany("Experiments")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("inkling.Models.Idea", b =>
                {
                    b.HasOne("inkling.Models.User")
                        .WithMany("Ideas")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("inkling.Models.Message", b =>
                {
                    b.HasOne("inkling.Models.Idea", "Idea")
                        .WithMany("Messages")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("inkling.Models.User", "Creator")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("inkling.Models.User", b =>
                {
                    b.HasOne("inkling.Models.Idea", "Idea")
                        .WithMany()
                        .HasForeignKey("IdeaId");
                });
#pragma warning restore 612, 618
        }
    }
}
