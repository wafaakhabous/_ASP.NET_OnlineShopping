using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelAsp1.Migrations
{
    /// <inheritdoc />
    public partial class image1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "Product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "Product",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
