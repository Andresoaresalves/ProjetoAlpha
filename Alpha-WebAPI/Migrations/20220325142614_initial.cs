using Microsoft.EntityFrameworkCore.Migrations;

namespace Alpha_WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Sigla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Documento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chefes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: false),
                    DepartamentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chefes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chefes_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuncionariosChefes",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(nullable: false),
                    ChefeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionariosChefes", x => new { x.FuncionarioId, x.ChefeId });
                    table.ForeignKey(
                        name: "FK_FuncionariosChefes_Chefes_ChefeId",
                        column: x => x.ChefeId,
                        principalTable: "Chefes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionariosChefes_funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "Nome", "Sigla" },
                values: new object[] { 1, "Administrativo", "ADM" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "Nome", "Sigla" },
                values: new object[] { 2, "Financeiro", "FIN" });

            migrationBuilder.InsertData(
                table: "funcionarios",
                columns: new[] { "Id", "Documento", "Nome", "Sobrenome" },
                values: new object[] { 1, "113247897", "Marta", "Silva" });

            migrationBuilder.InsertData(
                table: "funcionarios",
                columns: new[] { "Id", "Documento", "Nome", "Sobrenome" },
                values: new object[] { 2, "124567415", "Paula", "Souza" });

            migrationBuilder.InsertData(
                table: "funcionarios",
                columns: new[] { "Id", "Documento", "Nome", "Sobrenome" },
                values: new object[] { 3, "135218795", "Laura", "Santos" });

            migrationBuilder.InsertData(
                table: "funcionarios",
                columns: new[] { "Id", "Documento", "Nome", "Sobrenome" },
                values: new object[] { 4, "115155482", "Luisa", "Kent" });

            migrationBuilder.InsertData(
                table: "funcionarios",
                columns: new[] { "Id", "Documento", "Nome", "Sobrenome" },
                values: new object[] { 5, "135654357", "Lucas", "Alves" });

            migrationBuilder.InsertData(
                table: "funcionarios",
                columns: new[] { "Id", "Documento", "Nome", "Sobrenome" },
                values: new object[] { 6, "548468455", "Pedro", "Rocha" });

            migrationBuilder.InsertData(
                table: "funcionarios",
                columns: new[] { "Id", "Documento", "Nome", "Sobrenome" },
                values: new object[] { 7, "213546518", "Paulo", "Silveira" });

            migrationBuilder.InsertData(
                table: "Chefes",
                columns: new[] { "Id", "DepartamentoId", "Nome" },
                values: new object[] { 1, 1, "Rodrigo" });

            migrationBuilder.InsertData(
                table: "Chefes",
                columns: new[] { "Id", "DepartamentoId", "Nome" },
                values: new object[] { 2, 2, "Silvana" });

            migrationBuilder.InsertData(
                table: "FuncionariosChefes",
                columns: new[] { "FuncionarioId", "ChefeId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "FuncionariosChefes",
                columns: new[] { "FuncionarioId", "ChefeId" },
                values: new object[] { 6, 1 });

            migrationBuilder.InsertData(
                table: "FuncionariosChefes",
                columns: new[] { "FuncionarioId", "ChefeId" },
                values: new object[] { 7, 1 });

            migrationBuilder.InsertData(
                table: "FuncionariosChefes",
                columns: new[] { "FuncionarioId", "ChefeId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "FuncionariosChefes",
                columns: new[] { "FuncionarioId", "ChefeId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "FuncionariosChefes",
                columns: new[] { "FuncionarioId", "ChefeId" },
                values: new object[] { 4, 2 });

            migrationBuilder.InsertData(
                table: "FuncionariosChefes",
                columns: new[] { "FuncionarioId", "ChefeId" },
                values: new object[] { 5, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Chefes_DepartamentoId",
                table: "Chefes",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionariosChefes_ChefeId",
                table: "FuncionariosChefes",
                column: "ChefeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionariosChefes");

            migrationBuilder.DropTable(
                name: "Chefes");

            migrationBuilder.DropTable(
                name: "funcionarios");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
