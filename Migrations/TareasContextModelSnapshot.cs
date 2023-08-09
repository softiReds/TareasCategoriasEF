﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projectef.Context;

#nullable disable

namespace projectef.Migrations
{
    [DbContext(typeof(TareasContext))]
    partial class TareasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("projectef.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoriaDescripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoriaNombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("CategoriaPeso")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("e1a0019d-5685-4af5-8f81-d64ebad9bd00"),
                            CategoriaNombre = "Actividades pendientes",
                            CategoriaPeso = 20
                        },
                        new
                        {
                            CategoriaId = new Guid("e1a0019d-5685-4af5-8f81-d64ebad9bd01"),
                            CategoriaNombre = "Actividades personales",
                            CategoriaPeso = 50
                        });
                });

            modelBuilder.Entity("projectef.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DescripcionTarea")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("int");

                    b.Property<DateTime>("TareaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("TareaTitulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("e1a0019d-5685-4af5-8f81-d64ebad9bd02"),
                            CategoriaId = new Guid("e1a0019d-5685-4af5-8f81-d64ebad9bd00"),
                            PrioridadTarea = 1,
                            TareaCreacion = new DateTime(2023, 8, 8, 19, 16, 14, 720, DateTimeKind.Local).AddTicks(7333),
                            TareaTitulo = "Pago de serviciios publicos"
                        },
                        new
                        {
                            TareaId = new Guid("e1a0019d-5685-4af5-8f81-d64ebad9bd03"),
                            CategoriaId = new Guid("e1a0019d-5685-4af5-8f81-d64ebad9bd01"),
                            PrioridadTarea = 0,
                            TareaCreacion = new DateTime(2023, 8, 8, 19, 16, 14, 720, DateTimeKind.Local).AddTicks(7418),
                            TareaTitulo = "Terminar de ver pelicula en netflix"
                        });
                });

            modelBuilder.Entity("projectef.Models.Tarea", b =>
                {
                    b.HasOne("projectef.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("projectef.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
