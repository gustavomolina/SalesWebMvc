using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models.ModelosDeVisao
{
    //Classe que contem os dados necessários para se cadastrar um vendedor na View (seus dados e os dados do departamento) 
    public class VendedorFormViewModel
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
    }
}
