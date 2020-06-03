using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        //Construtor
        //Passa a chamada à classe 'base'
        public DbConcurrencyException(string mensagem) : base(mensagem)
        {

        }
    }
}
