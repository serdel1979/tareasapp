﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TareasAsp;

#nullable disable

namespace TareasAsp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240215053611_tarea-archivos")]
    partial class tareaarchivos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TareasAsp.Models.Entidades.ArchivoAdjunto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Orden")
                        .HasColumnType("integer");

                    b.Property<int>("TareaId")
                        .HasColumnType("integer");

                    b.Property<string>("Titulo")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TareaId");

                    b.ToTable("ArchivoAdjuntos");
                });

            modelBuilder.Entity("TareasAsp.Models.Entidades.Paso", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<int>("Orden")
                        .HasColumnType("integer");

                    b.Property<bool>("Realizado")
                        .HasColumnType("boolean");

                    b.Property<int>("TareaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TareaId");

                    b.ToTable("Pasos");
                });

            modelBuilder.Entity("TareasAsp.Models.Entidades.Tarea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Orden")
                        .HasColumnType("integer");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.ToTable("Tareas");
                });

            modelBuilder.Entity("TareasAsp.Models.Entidades.ArchivoAdjunto", b =>
                {
                    b.HasOne("TareasAsp.Models.Entidades.Tarea", "Tarea")
                        .WithMany("ArchivoAdjuntos")
                        .HasForeignKey("TareaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tarea");
                });

            modelBuilder.Entity("TareasAsp.Models.Entidades.Paso", b =>
                {
                    b.HasOne("TareasAsp.Models.Entidades.Tarea", "Tarea")
                        .WithMany("Pasos")
                        .HasForeignKey("TareaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tarea");
                });

            modelBuilder.Entity("TareasAsp.Models.Entidades.Tarea", b =>
                {
                    b.Navigation("ArchivoAdjuntos");

                    b.Navigation("Pasos");
                });
#pragma warning restore 612, 618
        }
    }
}
