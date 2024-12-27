using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApi.Migrations;

/// <inheritdoc />
public partial class MovingItemDbContext : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Items",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                BrandName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                Color = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                Ram = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                Rom = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                CameraMp = table.Column<int>(type: "integer", nullable: false),
                Image = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                Price = table.Column<decimal>(type: "numeric(18,2)", precision: 4, scale: 2, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Items", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Items");
    }
}
