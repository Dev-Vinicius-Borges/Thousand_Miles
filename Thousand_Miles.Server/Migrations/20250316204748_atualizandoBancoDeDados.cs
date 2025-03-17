using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thousand_Miles.Server.Migrations
{
    /// <inheritdoc />
    public partial class atualizandoBancoDeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Seguros_seguroid_seguro",
                table: "Reservas");

            migrationBuilder.RenameColumn(
                name: "plaxa",
                table: "Veiculos",
                newName: "placa");

            migrationBuilder.RenameColumn(
                name: "id_seguro",
                table: "Seguros",
                newName: "Id_seguro");

            migrationBuilder.RenameColumn(
                name: "seguroid_seguro",
                table: "Reservas",
                newName: "seguroId_seguro");

            migrationBuilder.RenameIndex(
                name: "IX_Reservas_seguroid_seguro",
                table: "Reservas",
                newName: "IX_Reservas_seguroId_seguro");

            migrationBuilder.AlterColumn<int>(
                name: "seguroId_seguro",
                table: "Reservas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Seguros_seguroId_seguro",
                table: "Reservas",
                column: "seguroId_seguro",
                principalTable: "Seguros",
                principalColumn: "Id_seguro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Seguros_seguroId_seguro",
                table: "Reservas");

            migrationBuilder.RenameColumn(
                name: "placa",
                table: "Veiculos",
                newName: "plaxa");

            migrationBuilder.RenameColumn(
                name: "Id_seguro",
                table: "Seguros",
                newName: "id_seguro");

            migrationBuilder.RenameColumn(
                name: "seguroId_seguro",
                table: "Reservas",
                newName: "seguroid_seguro");

            migrationBuilder.RenameIndex(
                name: "IX_Reservas_seguroId_seguro",
                table: "Reservas",
                newName: "IX_Reservas_seguroid_seguro");

            migrationBuilder.AlterColumn<int>(
                name: "seguroid_seguro",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Seguros_seguroid_seguro",
                table: "Reservas",
                column: "seguroid_seguro",
                principalTable: "Seguros",
                principalColumn: "id_seguro",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
