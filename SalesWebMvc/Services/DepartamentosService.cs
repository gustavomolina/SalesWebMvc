using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class DepartamentosService
    {
        private readonly SalesWebMvcContext _context;

        public DepartamentosService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //Retorna uma lista de departamentos

        public List<Departamento> FindAll()
        {

            //Ordena pelo nome
            return _context.Departamento.OrderBy(x => x.nome).ToList();

        }


    }
}
