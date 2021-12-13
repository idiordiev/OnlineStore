﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineStore.Models;

namespace OnlineStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211213171849_addedCategories")]
    partial class addedCategories
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineStore.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("OnlineStore.Models.Goods", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescriptionFullEN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionFullRU")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionFullUA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionShortEN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionShortRU")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionShortUA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameRU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameUA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Goods");
                });
#pragma warning restore 612, 618
        }
    }
}
