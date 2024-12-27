﻿// <auto-generated />
using System;
using EcommerceApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EcommerceApi.Migrations;

[DbContext(typeof(ItemDbContext))]
[Migration("20241116154838_MovingItemDbContext")]
partial class MovingItemDbContext
{
    /// <inheritdoc />
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "8.0.10")
            .HasAnnotation("Relational:MaxIdentifierLength", 63);

        NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

        modelBuilder.Entity("EcommerceApi.Models.Domains.Item", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<string>("BrandName")
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnType("character varying(30)");

                b.Property<int>("CameraMp")
                    .HasColumnType("integer");

                b.Property<string>("Color")
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnType("character varying(30)");

                b.Property<string>("Image")
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnType("character varying(300)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnType("character varying(30)");

                b.Property<decimal>("Price")
                    .HasPrecision(4, 2)
                    .HasColumnType("decimal(18,2)");

                b.Property<string>("Ram")
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnType("character varying(30)");

                b.Property<string>("Rom")
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnType("character varying(30)");

                b.HasKey("Id");

                b.ToTable("Items");
            });
#pragma warning restore 612, 618
    }
}
