using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordex.Locadora.Infraesctuture.Data.Migrations
{
    /// <inheritdoc />
    public partial class aluguelChaveVeiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoVeiculo",
                table: "Alugueis");

            migrationBuilder.AddColumn<string>(
                name: "PlacaVeiculo",
                table: "Alugueis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlacaVeiculo",
                table: "Alugueis");

            migrationBuilder.AddColumn<int>(
                name: "CodigoVeiculo",
                table: "Alugueis",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
