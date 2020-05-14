using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Departamento
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string nome { get; set; }

        //Cada departamento possui varios vendedores
        public ICollection<Vendedor> ColecaoVendedores { get; set; } = new List<Vendedor>();

        //Construtor vazio
        public Departamento()
        {

        }

        //Construtor com argumentos
        //Exceto atributos que são coleções

        public Departamento(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        //Métodos
        public void AdicionaVendedor(Vendedor vendedor)
        {
            ColecaoVendedores.Add(vendedor);
        }

        public void RemoveVendedor(Vendedor vendedor)
        {
            ColecaoVendedores.Remove(vendedor);
        }
        public void TransfereVendedor(Vendedor vendedor, Departamento NovoDepartamento)
        {
            //Adicionar o vendedor ao novo departmento
            NovoDepartamento.AdicionaVendedor(vendedor);

            //Remove este vendedor deste departamento
            ColecaoVendedores.Remove(vendedor);

        }

        public double TotalVendasPeriodo(DateTime datainicial, DateTime datafinal)
        {
            //Expressão LINQ para retornar (dentro do período estipulado) o total de vendas de todos os vendedores
            return ColecaoVendedores.Sum(vendedor => vendedor.TotalVendasPeriodo(datainicial, datafinal));
        }
    }
}
