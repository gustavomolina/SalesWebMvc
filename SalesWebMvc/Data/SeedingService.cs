using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        //Criado um novo context
        private SalesWebMvcContext _context;

        //Construtor
        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //Métodos
        public void Seed()
        {
            //Se houver algum registro nas tres tabelas a seguir
            if (_context.Departamento.Any() || _context.Vendas.Any() || _context.Vendedores.Any())
            {
                //Não popula a base
                return;
            }

            //População da base:
            Departamento departamento1 = new Departamento(1, "Eletronicos");
            Departamento departamento2 = new Departamento(2, "Eletrodomesticos");
            Departamento departamento3 = new Departamento(3, "Móveis");
            Departamento departamento4 = new Departamento(4, "Roupas");
            Departamento departamento5 = new Departamento(5, "Livros");

            Vendedor vendedor1 = new Vendedor(1, "Marcos", "marcos@gmail.com", new DateTime(1970, 02, 15), 1500.0, departamento1);
            Vendedor vendedor2 = new Vendedor(2, "João", "joao@gmail.com", new DateTime(1972, 03, 21), 1070.0, departamento2);
            Vendedor vendedor3 = new Vendedor(3, "Leonardo", "leonardo@gmail.com", new DateTime(1970, 02, 15), 1600.0, departamento3);
            Vendedor vendedor4 = new Vendedor(4, "Raquel", "raquel@gmail.com", new DateTime(1988, 09, 11), 1800.0, departamento4);
            Vendedor vendedor5 = new Vendedor(5, "José", "jose@gmail.com", new DateTime(1982, 03, 19), 1500.0, departamento5);
            Vendedor vendedor6 = new Vendedor(6, "Maria", "maria@gmail.com", new DateTime(1978, 12, 05), 1600.0, departamento4);
            Vendedor vendedor7 = new Vendedor(7, "Amanda", "amanda@gmail.com", new DateTime(1994, 12, 10), 2500.0, departamento2);

            Venda venda1 = new Venda(1, new DateTime(2020, 01, 09), 500, StatusVenda.pago, vendedor1);
            Venda venda2 = new Venda(2, new DateTime(2020, 02, 17), 300, StatusVenda.pago, vendedor2);
            Venda venda3 = new Venda(3, new DateTime(2020, 04, 09), 200, StatusVenda.pago, vendedor7);
            Venda venda4 = new Venda(4, new DateTime(2020, 02, 25), 500, StatusVenda.pago, vendedor5);
            Venda venda5 = new Venda(5, new DateTime(2020, 01, 23), 800, StatusVenda.pago, vendedor4);
            Venda venda6 = new Venda(6, new DateTime(2020, 03, 21), 600, StatusVenda.pago, vendedor3);
            Venda venda7 = new Venda(7, new DateTime(2020, 03, 12), 100, StatusVenda.pago, vendedor6);
            Venda venda8 = new Venda(8, new DateTime(2020, 04, 07), 900, StatusVenda.pago, vendedor2);
            Venda venda9 = new Venda(9, new DateTime(2020, 02, 12), 500, StatusVenda.pago, vendedor3);
            Venda venda10 = new Venda(10, new DateTime(2020, 02, 03), 300, StatusVenda.pago, vendedor5);
            Venda venda11 = new Venda(11, new DateTime(2020, 04, 05), 600, StatusVenda.pago, vendedor7);

            //Adiciona os registros acima ao banco de dados
            _context.Departamento.AddRange(departamento1, departamento2, departamento3, departamento4, departamento5);
            _context.Vendedores.AddRange(vendedor1, vendedor2, vendedor3, vendedor4, vendedor5, vendedor6, vendedor7);
            _context.Vendas.AddRange(venda1, venda2, venda3, venda4, venda5, venda6, venda7, venda8, venda9, venda10, venda11);

            //Salva as mudanças
            _context.SaveChanges();
        }
    }
}
