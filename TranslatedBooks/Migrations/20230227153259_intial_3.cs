using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslatedBooks.Migrations
{
    /// <inheritdoc />
    public partial class intial_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Authors",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Authors");
        }
    }
}
