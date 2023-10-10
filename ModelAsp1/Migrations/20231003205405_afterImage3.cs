using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelAsp1.Migrations
{
    /// <inheritdoc />
    public partial class afterImage3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ImageContentType",
                table: "Product",
                newName: "ImageFileName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageFileName",
                table: "Product",
                newName: "ImageContentType");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Product",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
