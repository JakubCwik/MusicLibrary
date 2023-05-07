﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KatalogMuzyczny.Migrations
{
    /// <inheritdoc />
    public partial class AddSongDuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "SongDuration",
                table: "Songs",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SongDuration",
                table: "Songs");
        }
    }
}
