using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendReservas.Service.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Rua = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Uf = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pais = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cep = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.EnderecoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Estabelecimentos",
                columns: table => new
                {
                    EstabelecimentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cnpj = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lotacao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HoraAbertura = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabelecimentos", x => x.EstabelecimentoId);
                    table.ForeignKey(
                        name: "FK_Estabelecimentos_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    AvaliacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AvaliacaoAtendimento = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    EstablelecimentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.AvaliacaoId);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Estabelecimentos_EstablelecimentoId",
                        column: x => x.EstablelecimentoId,
                        principalTable: "Estabelecimentos",
                        principalColumn: "EstabelecimentoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Fidelidades",
                columns: table => new
                {
                    FidelidadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    quantidadeReservas = table.Column<int>(type: "int", nullable: false),
                    quantidadeCancelamentos = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    EstablelecimentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fidelidades", x => x.FidelidadeId);
                    table.ForeignKey(
                        name: "FK_Fidelidades_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fidelidades_Estabelecimentos_EstablelecimentoId",
                        column: x => x.EstablelecimentoId,
                        principalTable: "Estabelecimentos",
                        principalColumn: "EstabelecimentoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    status = table.Column<int>(type: "int", nullable: false),
                    valor = table.Column<double>(type: "double", nullable: false),
                    dataReserva = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    horaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    horaFim = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    qtdPessoas = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    EstablelecimentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaId);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Estabelecimentos_EstablelecimentoId",
                        column: x => x.EstablelecimentoId,
                        principalTable: "Estabelecimentos",
                        principalColumn: "EstabelecimentoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Enderecos",
                columns: new[] { "EnderecoId", "Bairro", "Cep", "Cidade", "Numero", "Pais", "Rua", "Uf" },
                values: new object[] { 1, "Vila Israel", "13478540", "Americana", 850, "Brasil", "Avenida Nossa Senhora de Fátima", "SP" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Email", "EnderecoId", "Nome", "Senha", "Telefone" },
                values: new object[,]
                {
                    { 1, "teste@gmail.com", 1, "Henrique", "1234", "19971522927" },
                    { 2, "teste@gmail.com", 1, "Gabriel Cabral", "1234", "19971522927" },
                    { 3, "teste@gmail.com", 1, "Gabriel Oliveira", "1234", "19971522927" },
                    { 4, "teste@gmail.com", 1, "Carol", "1234", "19971522927" },
                    { 5, "teste@gmail.com", 1, "Eliana", "1234", "19971522927" }
                });

            migrationBuilder.InsertData(
                table: "Estabelecimentos",
                columns: new[] { "EstabelecimentoId", "Cnpj", "Descricao", "Email", "EnderecoId", "HoraAbertura", "Lotacao", "Senha", "Telefone" },
                values: new object[] { 1, "18340388000135", "McDonald's", "teste@gmail.com", 1, new DateTime(2021, 5, 30, 17, 17, 47, 970, DateTimeKind.Local).AddTicks(4791), "19971522927", "1234", "15" });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_ClienteId",
                table: "Avaliacoes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_EstablelecimentoId",
                table: "Avaliacoes",
                column: "EstablelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EnderecoId",
                table: "Clientes",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_EnderecoId",
                table: "Estabelecimentos",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fidelidades_ClienteId",
                table: "Fidelidades",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Fidelidades_EstablelecimentoId",
                table: "Fidelidades",
                column: "EstablelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ClienteId",
                table: "Reservas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_EstablelecimentoId",
                table: "Reservas",
                column: "EstablelecimentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "Fidelidades");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Estabelecimentos");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
