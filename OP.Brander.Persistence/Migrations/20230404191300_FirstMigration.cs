using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OP.Brander.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Formatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Formato = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Caracteristicas = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    FormatoPelicula = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    FeRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeBaja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Formatos__3214EC078BF374BA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genero = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    FeRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeBaja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Generos__3214EC078BF374BA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Director = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Argumento = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Duracion = table.Column<double>(type: "float", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    Formato = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: true),
                    FeRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeBaja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Peliculas__3214EC078BF374BA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pelicula_Genero",
                        column: x => x.Genero,
                        principalTable: "Generos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persona_Formato",
                        column: x => x.Formato,
                        principalTable: "Formatos",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Formatos",
                columns: new[] { "Id", "Caracteristicas", "FeBaja", "FeRegistro", "Formato", "FormatoPelicula" },
                values: new object[,]
                {
                    { 1, "Formato panorámico abandonado el 1963.", null, null, "Cinerama", "35mm" },
                    { 2, "Formato panorámico introducido el 1953.", null, null, "Cinemascope", "35mm" },
                    { 3, "Formato panorámico creado por Paramount Pictures.", null, null, "Vistavision", "" },
                    { 4, "Formato panorámico de resolución y definición muy elevada.", null, null, "IMAX", "70mm" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "FeBaja", "FeRegistro", "Genero" },
                values: new object[,]
                {
                    { 1, null, null, "Acción" },
                    { 2, null, null, "Aventuras" },
                    { 3, null, null, "Ciencia Ficción" },
                    { 4, null, null, "Ciencia Ficción" },
                    { 5, null, null, "No-Ficción/Documental" },
                    { 6, null, null, "Drama" },
                    { 7, null, null, "Fantasía" },
                    { 8, null, null, "Musical" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_Formato",
                table: "Peliculas",
                column: "Formato");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_Genero",
                table: "Peliculas",
                column: "Genero");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Formatos");
        }
    }
}
