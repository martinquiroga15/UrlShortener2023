﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoRegularizador.Migrations
{
    /// <inheritdoc />
    public partial class Agregamosname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Urls",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Urls");
        }
    }
}
