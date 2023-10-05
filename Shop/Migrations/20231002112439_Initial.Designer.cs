﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Shop;

#nullable disable

namespace Shop.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20231002112439_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Shop.Models.Beer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("availablbe")
                        .HasColumnType("boolean");

                    b.Property<int>("categoryID")
                        .HasColumnType("integer");

                    b.Property<string>("img")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isFavourite")
                        .HasColumnType("boolean");

                    b.Property<string>("longDesc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("price")
                        .HasColumnType("bigint");

                    b.Property<string>("shortDesc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("categoryID");

                    b.ToTable("Beer");
                });

            modelBuilder.Entity("Shop.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("categoryDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Shop.Models.Beer", b =>
                {
                    b.HasOne("Shop.Models.Category", "Category")
                        .WithMany("beer")
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Shop.Models.Category", b =>
                {
                    b.Navigation("beer");
                });
#pragma warning restore 612, 618
        }
    }
}
