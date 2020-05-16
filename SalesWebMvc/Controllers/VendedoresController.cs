using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class VendedoresController : Controller
    {

        //Dependencia para o VendedoresService
        //Dados
        private VendedoresService _vendedoresService;

        //Construtor
        public VendedoresController(VendedoresService vendedoresService)
        {
            _vendedoresService = vendedoresService;
        }

        //View Index para /Vendedores
        public IActionResult Index()
        {

            //Recebe uma lista de todos os vendedores
            
            var list = _vendedoresService.FindAll();

            //Lista como argumento à View
            return View(list);
        }

        //View para criar um Vendedor /Vendedor/Criar
        public IActionResult Criar()
        {
            return View();
        }

    }
}
