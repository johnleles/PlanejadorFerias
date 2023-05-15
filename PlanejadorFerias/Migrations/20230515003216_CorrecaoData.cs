﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanejadorFerias.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAdmissao",
                table: "Colaboradores",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataAdmissao",
                table: "Colaboradores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
