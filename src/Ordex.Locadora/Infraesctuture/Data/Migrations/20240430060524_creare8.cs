using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordex.Locadora.Infraesctuture.Data.Migrations
{
    /// <inheritdoc />
    public partial class creare8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Endereco_EnderecoCodigo",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoCodigo",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logadouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Codigo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EnderecoCodigo",
                table: "Clientes",
                column: "EnderecoCodigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Enderecos_EnderecoCodigo",
                table: "Clientes",
                column: "EnderecoCodigo",
                principalTable: "Enderecos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Enderecos_EnderecoCodigo",
                table: "Funcionarios",
                column: "EnderecoCodigo",
                principalTable: "Enderecos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Enderecos_EnderecoCodigo",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Enderecos_EnderecoCodigo",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_EnderecoCodigo",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "EnderecoCodigo",
                table: "Clientes");

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<int>(type: "int", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logadouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Codigo);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Endereco_EnderecoCodigo",
                table: "Funcionarios",
                column: "EnderecoCodigo",
                principalTable: "Endereco",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
