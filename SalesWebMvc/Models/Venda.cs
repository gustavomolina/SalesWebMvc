using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Venda
    {
        public int id { get; set; }
        public DateTime data { get; set; }
        public double total { get; set; }
        public StatusVenda status { get; set; }

        //Cada venda possui apenas um vendedor
        public Vendedor VendedorVenda { get; set; }

        //Construtor vazio
        public Venda()
        {

        }

        //Construtor com argumentos
        //Exceto atributos que são coleções
        public Venda(int id, DateTime data, double total, StatusVenda status, Vendedor vendedorVenda)
        {
            this.id = id;
            this.data = data;
            this.total = total;
            this.status = status;
            VendedorVenda = vendedorVenda;
        }
 

    }
}
