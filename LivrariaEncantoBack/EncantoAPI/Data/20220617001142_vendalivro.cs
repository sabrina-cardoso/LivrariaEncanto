using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncantoAPI.Data
{
    public partial class vendalivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VendaLivro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendaId = table.Column<int>(type: "int", nullable: true),
                    LivroId = table.Column<int>(type: "int", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaLivro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendaLivro_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VendaLivro_Vendas_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Vendas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VendaLivro_LivroId",
                table: "VendaLivro",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaLivro_VendaId",
                table: "VendaLivro",
                column: "VendaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendaLivro");
        }
    }
}
