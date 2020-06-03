using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;
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

        public Vendedor FindById(int id)
        {
            return _context.Vendedores.Include(obj => obj.DepartamentoVendedor).FirstOrDefault(obj => obj.id == id);

        }

        //Deletar vendedor
        public void Remove(int id)
        {
            var obj = _context.Vendedores.Find(id);
            _context.Vendedores.Remove(obj);
            _context.SaveChanges();

        
        }

        //Método para atualizar características do vendedor
        public void Update(Vendedor vendedor)
        {
            //Verifica se o vendedor está na base de dados
            if(!_context.Vendedores.Any(x => x.id == vendedor.id))
            {
                throw new NotFoundException("Id não encontrado!");
            }
            //Verifica se a operação de update ocorreu com sucesso
            try
            {
                _context.Update(vendedor);
                _context.SaveChanges();
            }
            /*Se ocorreu um erro de concorrencia na atualização dos dados ('DbUpdateConcurrencyException'), é acionada
            a excessão que foi gerada na camada de serviços*/
            catch (DbUpdateConcurrencyException excessao)
            {
                throw new DbConcurrencyException(excessao.Message);
            }

            /*Esta operação é muito importante para manter a independencia entre as stacks do projeto, de maneira que
            uma excessão gerada na camada de dados não será propagada a camada de serviços.
            Desta forma é preservada            a ideia de os controllers só se comunicarem com a camada de serviços
            que então faz o tratamento dos dados da aplicação na base de dados. Este conceito é fundamental no desen-
            volvimento de sistemas.
            */
        }
    }
}
