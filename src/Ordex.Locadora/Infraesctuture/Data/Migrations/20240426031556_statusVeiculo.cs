using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordex.Locadora.Infraesctuture.Data.Migrations
{
    /// <inheritdoc />
    public partial class statusVeiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Veiculos",
                type: "bit",
                nullable: false,
                defaultValue: false);
 
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Veiculos"); 
        }
    }
}
