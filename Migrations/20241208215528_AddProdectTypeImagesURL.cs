using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NikePro.Migrations
{
    /// <inheritdoc />
    public partial class AddProdectTypeImagesURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductTypeImagesURL",
                table: "ProductTypes",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductTypeImagesURL",
                table: "ProductTypes");
        }
    }
}
