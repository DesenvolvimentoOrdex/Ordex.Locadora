using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordex.Locadora.Infraesctuture.Data.Migrations
{
    /// <inheritdoc />
    public partial class ajusteluguel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalComDesconto",
                table: "Alugueis",
                newName: "PossuiDesconto");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Alugueis",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<double>(
                name: "ValorComDesconto",
                table: "Alugueis",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorComDesconto",
                table: "Alugueis");

            migrationBuilder.RenameColumn(
                name: "PossuiDesconto",
                table: "Alugueis",
                newName: "TotalComDesconto");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Alugueis",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
