using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelAsp1.Migrations
{
    /// <inheritdoc />
    public partial class imageFinale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageFileName",
                table: "Product",
                newName: "imageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imageUrl",
                table: "Product",
                newName: "ImageFileName");
        }
    }
}
