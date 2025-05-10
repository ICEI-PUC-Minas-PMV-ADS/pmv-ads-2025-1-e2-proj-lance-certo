using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanceCerto.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AjustesFinaisNosModelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImoveisFavoritos_Imoveis_ImovelId",
                table: "ImoveisFavoritos");

            migrationBuilder.DropForeignKey(
                name: "FK_ImoveisFavoritos_Usuarios_UsuarioId",
                table: "ImoveisFavoritos");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensagens_Imoveis_ImovelRelacionadoId",
                table: "Mensagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensagens_Usuarios_DestinatarioId",
                table: "Mensagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensagens_Usuarios_RemetenteId",
                table: "Mensagens");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Conteudo",
                table: "Mensagens",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImoveisFavoritos_Imoveis_ImovelId",
                table: "ImoveisFavoritos",
                column: "ImovelId",
                principalTable: "Imoveis",
                principalColumn: "ImovelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImoveisFavoritos_Usuarios_UsuarioId",
                table: "ImoveisFavoritos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagens_Imoveis_ImovelRelacionadoId",
                table: "Mensagens",
                column: "ImovelRelacionadoId",
                principalTable: "Imoveis",
                principalColumn: "ImovelId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagens_Usuarios_DestinatarioId",
                table: "Mensagens",
                column: "DestinatarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagens_Usuarios_RemetenteId",
                table: "Mensagens",
                column: "RemetenteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImoveisFavoritos_Imoveis_ImovelId",
                table: "ImoveisFavoritos");

            migrationBuilder.DropForeignKey(
                name: "FK_ImoveisFavoritos_Usuarios_UsuarioId",
                table: "ImoveisFavoritos");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensagens_Imoveis_ImovelRelacionadoId",
                table: "Mensagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensagens_Usuarios_DestinatarioId",
                table: "Mensagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensagens_Usuarios_RemetenteId",
                table: "Mensagens");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Usuarios",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Conteudo",
                table: "Mensagens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImoveisFavoritos_Imoveis_ImovelId",
                table: "ImoveisFavoritos",
                column: "ImovelId",
                principalTable: "Imoveis",
                principalColumn: "ImovelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImoveisFavoritos_Usuarios_UsuarioId",
                table: "ImoveisFavoritos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagens_Imoveis_ImovelRelacionadoId",
                table: "Mensagens",
                column: "ImovelRelacionadoId",
                principalTable: "Imoveis",
                principalColumn: "ImovelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagens_Usuarios_DestinatarioId",
                table: "Mensagens",
                column: "DestinatarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagens_Usuarios_RemetenteId",
                table: "Mensagens",
                column: "RemetenteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
