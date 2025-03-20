﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelancePlatform.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class erdemsincer1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserRoles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserRoles",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
