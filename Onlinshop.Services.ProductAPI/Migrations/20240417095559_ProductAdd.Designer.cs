﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OnlineShop.Services.ProductAPI.Data;

#nullable disable

namespace Onlineshop.Services.ProductAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240417095559_ProductAdd")]
    partial class ProductAdd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Onlineshop.Services.ProductAPI.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("ProductCategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Кружка ST градиент",
                            Name = "Кружка",
                            PictureUrl = "https://www.modi.ru/upload/resize_cache/product/3d8/250_273_240cd750bba9870f18aada2478b24840a/mm3ndp9890r7d40bck42bq6b4q0seugp.jpg",
                            Price = 299.0,
                            ProductCategoryName = "Посуда"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Тарелка 26 см",
                            Name = "Тарелка",
                            PictureUrl = "https://www.modi.ru/upload/resize_cache/product/b48/250_273_240cd750bba9870f18aada2478b24840a/4iihmyj7kflksk5a1gn8ax3vo21yu2z4.jpg",
                            Price = 299.0,
                            ProductCategoryName = "Посуда"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
