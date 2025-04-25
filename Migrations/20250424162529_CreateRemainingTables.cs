using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanceCerto.WebApp.Migrations
{
    public partial class CreateRemainingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Imoveis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EhVendedor = table.Column<bool>(type: "bit", nullable: false),
                    EhCorretor = table.Column<bool>(type: "bit", nullable: false),
                    Creci = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "ImoveisFavoritos",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ImovelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImoveisFavoritos", x => new { x.UsuarioId, x.ImovelId });
                    table.ForeignKey(
                        name: "FK_ImoveisFavoritos_Imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imoveis",
                        principalColumn: "ImovelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImoveisFavoritos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leiloes",
                columns: table => new
                {
                    LeilaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImovelId = table.Column<int>(type: "int", nullable: false),
                    VencedorId = table.Column<int>(type: "int", nullable: true),
                    InicioEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FimEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaiorLanceAtual = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leiloes", x => x.LeilaoId);
                    table.ForeignKey(
                        name: "FK_Leiloes_Imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imoveis",
                        principalColumn: "ImovelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leiloes_Usuarios_VencedorId",
                        column: x => x.VencedorId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Mensagens",
                columns: table => new
                {
                    MensagemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RemetenteId = table.Column<int>(type: "int", nullable: false),
                    DestinatarioId = table.Column<int>(type: "int", nullable: false),
                    ImovelRelacionadoId = table.Column<int>(type: "int", nullable: true),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnviadaEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagens", x => x.MensagemId);
                    table.ForeignKey(
                        name: "FK_Mensagens_Imoveis_ImovelRelacionadoId",
                        column: x => x.ImovelRelacionadoId,
                        principalTable: "Imoveis",
                        principalColumn: "ImovelId");
                    table.ForeignKey(
                        name: "FK_Mensagens_Usuarios_DestinatarioId",
                        column: x => x.DestinatarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mensagens_Usuarios_RemetenteId",
                        column: x => x.RemetenteId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lances",
                columns: table => new
                {
                    LanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeilaoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ValorLance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MomentoLance = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lances", x => x.LanceId);
                    table.ForeignKey(
                        name: "FK_Lances_Leiloes_LeilaoId",
                        column: x => x.LeilaoId,
                        principalTable: "Leiloes",
                        principalColumn: "LeilaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lances_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(name: "IX_Imoveis_UsuarioId", table: "Imoveis", column: "UsuarioId");
            migrationBuilder.CreateIndex(name: "IX_ImoveisFavoritos_ImovelId", table: "ImoveisFavoritos", column: "ImovelId");
            migrationBuilder.CreateIndex(name: "IX_Lances_LeilaoId", table: "Lances", column: "LeilaoId");
            migrationBuilder.CreateIndex(name: "IX_Lances_UsuarioId", table: "Lances", column: "UsuarioId");
            migrationBuilder.CreateIndex(name: "IX_Leiloes_ImovelId", table: "Leiloes", column: "ImovelId");
            migrationBuilder.CreateIndex(name: "IX_Leiloes_VencedorId", table: "Leiloes", column: "VencedorId");
            migrationBuilder.CreateIndex(name: "IX_Mensagens_DestinatarioId", table: "Mensagens", column: "DestinatarioId");
            migrationBuilder.CreateIndex(name: "IX_Mensagens_ImovelRelacionadoId", table: "Mensagens", column: "ImovelRelacionadoId");
            migrationBuilder.CreateIndex(name: "IX_Mensagens_RemetenteId", table: "Mensagens", column: "RemetenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Usuarios_UsuarioId",
                table: "Imoveis",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Imoveis_Usuarios_UsuarioId", table: "Imoveis");

            migrationBuilder.DropTable(name: "ImoveisFavoritos");
            migrationBuilder.DropTable(name: "Lances");
            migrationBuilder.DropTable(name: "Mensagens");
            migrationBuilder.DropTable(name: "Leiloes");
            migrationBuilder.DropTable(name: "Usuarios");

            migrationBuilder.DropIndex(name: "IX_Imoveis_UsuarioId", table: "Imoveis");
            migrationBuilder.DropColumn(name: "UsuarioId", table: "Imoveis");
        }
    }
}