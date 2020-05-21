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
        
        //Implementa um FindAll que retorna uma lista de vendedores
       
        public List<Vendedor> FindAll()
        {
            return _context.Vendedores.ToList();
        }

        //Serviço para adicionar o registro de um novo vendedor à base
        public void Insert(Vendedor vendedor)
        {
            vendedor.DepartamentoVendedor = _context.Departamento.First();
            _context.Add(vendedor);
            _context.SaveChanges();
        }
    }
}
