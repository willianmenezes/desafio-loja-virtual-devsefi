using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevEficiente.LojaVirtual.Data.Migrations
{
    /// <inheritdoc />
    public partial class AjustaEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Estado_IdEstado",
                table: "Compras");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdEstado",
                table: "Compras",
                column: "IdEstado");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Estado_IdEstado",
                table: "Compras",
                column: "IdEstado",
                principalTable: "Estados",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Estado_IdEstado",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_IdEstado",
                table: "Compras");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Estado_IdEstado",
                table: "Compras",
                column: "IdPais",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
