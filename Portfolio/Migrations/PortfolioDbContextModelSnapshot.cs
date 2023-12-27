﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portfolio.Data;

#nullable disable

namespace Portfolio.Migrations
{
    [DbContext(typeof(PortfolioDbContext))]
    partial class PortfolioDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Portfolio.Api.Models.ContactMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "content");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)")
                        .HasAnnotation("Relational:JsonPropertyName", "createdOn");

                    b.Property<string>("FromEmail")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "email");

                    b.Property<string>("FromName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<string>("Subject")
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "subject");

                    b.HasKey("Id");

                    b.ToTable("ContactMessages");
                });
#pragma warning restore 612, 618
        }
    }
}