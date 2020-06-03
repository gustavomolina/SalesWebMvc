using System;


namespace SalesWebMvc.Services.Exceptions
{
    public class NotFoundException : ApplicationException
        //Classe para excessoes específicas da camada de serviço
    {


        //Construtor
        //Passa a chamada à classe 'base'
        public NotFoundException(string mensagem) : base(mensagem)
        {

        }
    }
}
