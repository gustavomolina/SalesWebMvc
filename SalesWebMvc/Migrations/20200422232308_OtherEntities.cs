using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMvc.Migrations
{
    public partial class OtherEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    nascimento = table.Column<DateTime>(nullable: false),
                    salariobase = table.Column<double>(nullable: false),
                    DepartamentoVendedorid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vendedores_Departamento_DepartamentoVendedorid",
                        column: x => x.DepartamentoVendedorid,
                        principalTable: "Departamento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data = table.Column<DateTime>(nullable: false),
                    total = table.Column<double>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    VendedorVendaid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vendas_Vendedores_VendedorVendaid",
                        column: x => x.VendedorVendaid,
                        principalTable: "Vendedores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VendedorVendaid",
                table: "Vendas",
                column: "VendedorVendaid");

            migrationBuilder.CreateIndex(
                name: "IX_Vendedores_DepartamentoVendedorid",
                table: "Vendedores",
                column: "DepartamentoVendedorid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Vendedores");
        }
    }
}
