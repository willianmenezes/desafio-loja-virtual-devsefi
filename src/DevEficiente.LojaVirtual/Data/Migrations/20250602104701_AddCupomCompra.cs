using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevEficiente.LojaVirtual.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCupomCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdCupom",
                table: "Compras",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdCupom",
                table: "Compras",
                column: "IdCupom");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Cupom_IdCupom",
                table: "Compras",
                column: "IdCupom",
                principalTable: "Cupons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Cupom_IdCupom",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_IdCupom",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "IdCupom",
                table: "Compras");
        }
    }
}
