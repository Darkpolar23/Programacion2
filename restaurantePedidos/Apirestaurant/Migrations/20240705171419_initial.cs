using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apirestaurant.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelsRestaurants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Full_nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numeropedido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detallespedidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costopedido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fechapedido = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelsRestaurants", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelsRestaurants");
        }
    }
}
