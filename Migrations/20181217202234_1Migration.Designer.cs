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
    [Migration("20181217202234_1Migration")]
    partial class _1Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("inkling.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created_at");

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

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
