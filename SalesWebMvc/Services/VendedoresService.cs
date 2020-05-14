using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class VendedoresService
    {
        private readonly SalesWebMvcContext _context;
        public VendedoresService(SalesWebMvcContext context)
        {
            _context = context;
        }
        
        //Implementar FindAll que retorna uma lista de vendedores
       
        public List<Vendedor> FindAll()
        {
            return _context.Vendedores.ToList();
        }
    }
}
