using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelAsp1.Migrations
{
    /// <inheritdoc />
    public partial class afterImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageContentType",
                table: "Product",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Product",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageContentType",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Product");
        }
    }
}
