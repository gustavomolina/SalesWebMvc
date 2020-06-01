using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Vendedor
    {
        
        public  int id { get; set; }
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Display(Name = "E-mail")]
        public string email { get; set; }
        [Display(Name = "Nascimento")]
        public DateTime nascimento { get; set; }
        [Display(Name = "Salário Base")]
        public double salariobase { get; set; }

        //Cada vendedor possui um departamento
        public Departamento DepartamentoVendedor { get; set; }
        public int DepartamentoId { get; set; }

        //Cada vendedor possui varias vendas
        //Ja instanciado por garantia
        public ICollection<Venda> VendasVendedor { get; set; } = new List<Venda>();

        //Construtor vazio
        public Vendedor()
        {

        }

        //Construtor com argumentos
        //Exceto atributos que são coleções
        public Vendedor(int id, string nome, string email, DateTime nascimento, double salariobase, Departamento departamentoVendedor)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.nascimento = nascimento;
            this.salariobase = salariobase;
            this.DepartamentoVendedor = departamentoVendedor;
        }

        //Métodos
        public void AdicionaVenda(Venda venda)
        {
            VendasVendedor.Add(venda);
        }
        
        public void RemoveVenda(Venda venda)
        {
            this.VendasVendedor.Remove(venda);
        }

        //Retorna o Valor total vendido pelo vendedor
        public double TotalVendasPeriodo(DateTime datainicial, DateTime datafinal)
        {
            /*double valortotal = 0;

            foreach(Venda variavelVenda in VendasVendedor)
            {
                //Se a venda estiver dentro do prazo passado, o seu valor é contabilizado
                if(variavelVenda.data >= datainicial && variavelVenda.data <= datafinal) valortotal += variavelVenda.total;
            }

            return valortotal;*/


            //Expressã LINQ, mais otimizada
            return VendasVendedor.Where(venda => venda.data >= datainicial && venda.data <= datafinal)
                .Sum(venda => venda.total);
        }


    }
}
