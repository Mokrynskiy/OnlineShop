﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OnlineShop.Services.DiscountAPI.Data;

#nullable disable

namespace OnlineShop.Services.DiscountAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OnlineShop.Services.DiscountAPI.Models.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("DiscountAmount")
                        .HasColumnType("double precision");

                    b.Property<string>("DiscountCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MinAmount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Discounts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DiscountAmount = 10.0,
                            DiscountCode = "10DFF",
                            MinAmount = 20
                        },
                        new
                        {
                            Id = 2,
                            DiscountAmount = 20.0,
                            DiscountCode = "20DFF",
                            MinAmount = 40
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
