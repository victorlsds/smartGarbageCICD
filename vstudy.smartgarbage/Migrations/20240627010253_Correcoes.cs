using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vstudy.smartgarbage.Migrations
{
    /// <inheritdoc />
    public partial class Correcoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_SG_PONTOSCOLETA",
                columns: table => new
                {
                    PontoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TipoLogradouro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Logradouro = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<int>(type: "NUMBER(10)", maxLength: 5, nullable: false),
                    CEP = table.Column<string>(type: "NVARCHAR2(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_SG_PONTOSCOLETA", x => x.PontoId);
                });

            migrationBuilder.CreateTable(
                name: "TBL_SG_USUARIO",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Role = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_SG_USUARIO", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "TBL_SG_AGENDACOLETA",
                columns: table => new
                {
                    AgendamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataAgendamento = table.Column<DateTime>(type: "date", nullable: false),
                    PontoColetaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_SG_AGENDACOLETA", x => x.AgendamentoId);
                    table.ForeignKey(
                        name: "FK_TBL_SG_AGENDACOLETA_TBL_SG_PONTOSCOLETA_PontoColetaId",
                        column: x => x.PontoColetaId,
                        principalTable: "TBL_SG_PONTOSCOLETA",
                        principalColumn: "PontoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_SG_AGENDACOLETA_TBL_SG_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TBL_SG_USUARIO",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_SG_FEEDBACK",
                columns: table => new
                {
                    FeedBackId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AgendamentoColetaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Mensagem = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    DataFeedback = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_SG_FEEDBACK", x => x.FeedBackId);
                    table.ForeignKey(
                        name: "FK_TBL_SG_FEEDBACK_TBL_SG_AGENDACOLETA_AgendamentoColetaId",
                        column: x => x.AgendamentoColetaId,
                        principalTable: "TBL_SG_AGENDACOLETA",
                        principalColumn: "AgendamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_SG_FEEDBACK_TBL_SG_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TBL_SG_USUARIO",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_SG_RESIDUOCOLETA",
                columns: table => new
                {
                    ResiduoColetaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TipoResiduo = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    AgendamentoColetaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_SG_RESIDUOCOLETA", x => x.ResiduoColetaId);
                    table.ForeignKey(
                        name: "FK_TBL_SG_RESIDUOCOLETA_TBL_SG_AGENDACOLETA_AgendamentoColetaId",
                        column: x => x.AgendamentoColetaId,
                        principalTable: "TBL_SG_AGENDACOLETA",
                        principalColumn: "AgendamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_SG_AGENDACOLETA_PontoColetaId",
                table: "TBL_SG_AGENDACOLETA",
                column: "PontoColetaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_SG_AGENDACOLETA_UsuarioId",
                table: "TBL_SG_AGENDACOLETA",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_SG_FEEDBACK_AgendamentoColetaId",
                table: "TBL_SG_FEEDBACK",
                column: "AgendamentoColetaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_SG_FEEDBACK_UsuarioId",
                table: "TBL_SG_FEEDBACK",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_SG_RESIDUOCOLETA_AgendamentoColetaId",
                table: "TBL_SG_RESIDUOCOLETA",
                column: "AgendamentoColetaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_SG_FEEDBACK");

            migrationBuilder.DropTable(
                name: "TBL_SG_RESIDUOCOLETA");

            migrationBuilder.DropTable(
                name: "TBL_SG_AGENDACOLETA");

            migrationBuilder.DropTable(
                name: "TBL_SG_PONTOSCOLETA");

            migrationBuilder.DropTable(
                name: "TBL_SG_USUARIO");
        }
    }
}
