using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevEficiente.LojaVirtual.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCupom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cupons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PercentualDesconto = table.Column<int>(type: "integer", nullable: false),
                    Validade = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdCompra",
                table: "Pedidos",
                column: "IdCompra",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Compra_IdCompra",
                table: "Pedidos",
                column: "IdCompra",
                principalTable: "Compras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Compra_IdCompra",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "Cupons");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_IdCompra",
                table: "Pedidos");
        }
    }
}
