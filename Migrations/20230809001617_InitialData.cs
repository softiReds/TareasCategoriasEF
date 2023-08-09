using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DescripcionTarea",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CategoriaDescripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "CategoriaDescripcion", "CategoriaNombre", "CategoriaPeso" },
                values: new object[,]
                {
                    { new Guid("e1a0019d-5685-4af5-8f81-d64ebad9bd00"), null, "Actividades pendientes", 20 },
                    { new Guid("e1a0019d-5685-4af5-8f81-d64ebad9bd01"), null, "Actividades personales", 50 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "DescripcionTarea", "PrioridadTarea", "TareaCreacion", "TareaTitulo" },
                values: new object[,]
                {
                    { new Guid("e1a0019d-5685-4af5-8f81-d64ebad9bd02"), new Guid("e1a0019d-5685-4af5-8f81-d64ebad9bd00"), null, 1, new DateTime(2023, 8, 8, 19, 16, 14, 720, DateTimeKind.Local).AddTicks(7333), "Pago de serviciios publicos" },
                    { new Guid("e1a0019d-5685-4af5-8f81-d64ebad9bd03"), new Guid("e1a0019d-5685-4af5-8f81-d64ebad9bd01"), null, 0, new DateTime(2023, 8, 8, 19, 16, 14, 720, DateTimeKind.Local).AddTicks(7418), "Terminar de ver pelicula en netflix" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("e1a0019d-5685-4af5-8f81-d64ebad9bd02"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("e1a0019d-5685-4af5-8f81-d64ebad9bd03"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("e1a0019d-5685-4af5-8f81-d64ebad9bd00"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("e1a0019d-5685-4af5-8f81-d64ebad9bd01"));

            migrationBuilder.AlterColumn<string>(
                name: "DescripcionTarea",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoriaDescripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
