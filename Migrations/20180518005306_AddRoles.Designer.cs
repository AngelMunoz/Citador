﻿// <auto-generated />
using Citador.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Citador.Migrations
{
    [DbContext(typeof(CitadorContext))]
    [Migration("20180518005306_AddRoles")]
    partial class AddRoles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("Citador.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Area")
                        .HasMaxLength(30);

                    b.Property<string>("Role")
                        .HasMaxLength(30);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Citador.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .HasMaxLength(80);

                    b.Property<string>("Name")
                        .HasMaxLength(80);

                    b.Property<string>("Password")
                        .HasMaxLength(120);

                    b.Property<string>("Username")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Citador.Models.Permission", b =>
                {
                    b.HasOne("Citador.Models.User", "User")
                        .WithMany("Permissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
