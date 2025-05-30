using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevEficiente.LojaVirtual.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPais = table.Column<Guid>(type: "uuid", nullable: false),
                    IdEstado = table.Column<Guid>(type: "uuid", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, nullable: false),
                    SobreNome = table.Column<string>(type: "varchar(100)", unicode: false, nullable: false),
                    Documento = table.Column<string>(type: "varchar(14)", unicode: false, nullable: false),
                    Endereco = table.Column<string>(type: "varchar(250)", unicode: false, nullable: false),
                    Complemento = table.Column<string>(type: "varchar(250)", unicode: false, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", unicode: false, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(11)", unicode: false, nullable: false),
                    Cep = table.Column<string>(type: "varchar(8)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compra_Estado_IdEstado",
                        column: x => x.IdPais,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compra_Pais_IdPais",
                        column: x => x.IdPais,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdPais",
                table: "Compras",
                column: "IdPais");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");
        }
    }
}
