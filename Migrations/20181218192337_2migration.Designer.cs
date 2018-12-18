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
    [Migration("20181218192337_2migration")]
    partial class _2migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("inkling.Models.Approver", b =>
                {
                    b.Property<int>("ApproverId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdeaId");

                    b.Property<int>("UserId");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("ApproverId");

                    b.ToTable("Approver");
                });

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

            modelBuilder.Entity("inkling.Models.Edd", b =>
                {
                    b.Property<int>("EddId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Eddlink")
                        .IsRequired();

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("EddId");

                    b.ToTable("Edd");
                });

            modelBuilder.Entity("inkling.Models.Idea", b =>
                {
                    b.Property<int>("IdeaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ApproverId");

                    b.Property<int>("EddId");

                    b.Property<DateTime>("created_at");

                    b.Property<string>("desc")
                        .IsRequired();

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<DateTime>("updated_at");

                    b.HasKey("IdeaId");

                    b.HasIndex("ApproverId");

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

            modelBuilder.Entity("inkling.Models.Results", b =>
                {
                    b.Property<int>("ResultId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EddId1");

                    b.Property<DateTime>("created_at");

                    b.Property<string>("result")
                        .IsRequired();

                    b.Property<DateTime>("updated_at");

                    b.HasKey("ResultId");

                    b.HasIndex("EddId1");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("inkling.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ApproverId");

                    b.Property<int?>("IdeaId");

                    b.Property<DateTime>("created_at");

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("fname")
                        .IsRequired();

                    b.Property<string>("lname")
                        .IsRequired();

                    b.Property<string>("password")
                        .IsRequired();

                    b.Property<int>("rank");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("UserId");

                    b.HasIndex("ApproverId");

                    b.HasIndex("IdeaId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("inkling.Models.Department", b =>
                {
                    b.HasOne("inkling.Models.Idea", "Idea")
                        .WithMany("Department")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("inkling.Models.User", "User")
                        .WithMany("department")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("inkling.Models.Idea", b =>
                {
                    b.HasOne("inkling.Models.Approver")
                        .WithMany("idea")
                        .HasForeignKey("ApproverId");
                });

            modelBuilder.Entity("inkling.Models.Message", b =>
                {
                    b.HasOne("inkling.Models.Idea", "Idea")
                        .WithMany("message")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("inkling.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("inkling.Models.Results", b =>
                {
                    b.HasOne("inkling.Models.Edd", "EddId")
                        .WithMany("Result")
                        .HasForeignKey("EddId1");
                });

            modelBuilder.Entity("inkling.Models.User", b =>
                {
                    b.HasOne("inkling.Models.Approver")
                        .WithMany("User")
                        .HasForeignKey("ApproverId");

                    b.HasOne("inkling.Models.Idea")
                        .WithMany("User")
                        .HasForeignKey("IdeaId");
                });
#pragma warning restore 612, 618
        }
    }
}
