using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AcademiaApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class primeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Preco = table.Column<long>(type: "INTEGER", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataRevisao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GrupoMuscularPrincipal = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManutencoesEquipamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataFeita = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descritivo = table.Column<string>(type: "TEXT", nullable: false),
                    EstadoEquipamento = table.Column<int>(type: "INTEGER", nullable: false),
                    FoiUtilizadaRecentemente = table.Column<bool>(type: "INTEGER", nullable: false),
                    VezesUtilizadaSemanaAnterior = table.Column<int>(type: "INTEGER", nullable: true),
                    EquipamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManutencoesEquipamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManutencoesEquipamento_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Equipamentos",
                columns: new[] { "Id", "DataCompra", "DataRevisao", "Descricao", "GrupoMuscularPrincipal", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pernas (quadríceps, glúteos)", "Leg Press", 8500L },
                    { 2, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Peitoral", "Supino Reto", 5200L },
                    { 3, new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Costas (latíssimo do dorso)", "Puxada Frente (Pulldown)", 4700L },
                    { 4, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Quadríceps", "Cadeira Extensora", 4000L },
                    { 5, new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Glúteos e abdutores", "Cadeira Abdutora", 3800L },
                    { 6, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Peitoral, ombros e pernas", "Smith Machine (Máquina Smith)", 9000L },
                    { 7, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bíceps", "Rosca Scott", 3600L },
                    { 8, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tríceps", "Tríceps Testa (com polia)", 3200L },
                    { 9, new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Peitoral", "Peck Deck (voador)", 5500L },
                    { 10, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Costas (dorsais, romboides)", "Remada Baixa", 4900L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManutencoesEquipamento_EquipamentoId",
                table: "ManutencoesEquipamento",
                column: "EquipamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManutencoesEquipamento");

            migrationBuilder.DropTable(
                name: "Equipamentos");
        }
    }
}
