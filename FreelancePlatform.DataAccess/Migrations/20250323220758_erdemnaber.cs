using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelancePlatform.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class erdemnaber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserSkills");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserSkills",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
