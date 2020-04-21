using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            //Lista de departamentos para serem apresentados à view
            List<Departamento> lista = new List<Departamento>();

            //Adicionar departamento
            lista.Add(new Departamento { id = 1, nome = "Eletronicos"});
            lista.Add(new Departamento { id = 2, nome = "Moda" });

            //Enviar dados à View
            return View(lista);
        }
    }
}
