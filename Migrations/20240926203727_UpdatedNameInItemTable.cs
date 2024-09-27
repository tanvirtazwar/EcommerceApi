using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedNameInItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Images",
                table: "Items",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Items",
                newName: "Images");
        }
    }
}
