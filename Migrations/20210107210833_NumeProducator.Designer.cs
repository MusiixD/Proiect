﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect.Data;

namespace Proiect.Migrations
{
    [DbContext(typeof(ProiectContext))]
    [Migration("20210107210833_NumeProducator")]
    partial class NumeProducator
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Proiect.Models.Categorie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NumeCategorie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("Proiect.Models.CategorieTelefoane", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategorieID")
                        .HasColumnType("int");

                    b.Property<int>("IDCategorie")
                        .HasColumnType("int");

                    b.Property<int>("IDTelefon")
                        .HasColumnType("int");

                    b.Property<int?>("TelefonID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategorieID");

                    b.HasIndex("TelefonID");

                    b.ToTable("CategorieTelefoane");
                });

            modelBuilder.Entity("Proiect.Models.Producator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NumeProducator")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Producator");
                });

            modelBuilder.Entity("Proiect.Models.Telefon", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataLansarii")
                        .HasColumnType("datetime2");

                    b.Property<string>("Denumire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDProducator")
                        .HasColumnType("int");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<int?>("ProducatorID")
                        .HasColumnType("int");

                    b.Property<string>("So")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ProducatorID");

                    b.ToTable("Telefon");
                });

            modelBuilder.Entity("Proiect.Models.CategorieTelefoane", b =>
                {
                    b.HasOne("Proiect.Models.Categorie", "Categorie")
                        .WithMany("CategoriiTelefoane")
                        .HasForeignKey("CategorieID");

                    b.HasOne("Proiect.Models.Telefon", "Telefon")
                        .WithMany("CategoriiTelefoane")
                        .HasForeignKey("TelefonID");
                });

            modelBuilder.Entity("Proiect.Models.Telefon", b =>
                {
                    b.HasOne("Proiect.Models.Producator", "Producator")
                        .WithMany("Telefoane")
                        .HasForeignKey("ProducatorID");
                });
#pragma warning restore 612, 618
        }
    }
}
