using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ModelosDeVisao;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class VendedoresController : Controller
    {

        //Dependencia para o VendedoresService
        //Dados
        private VendedoresService _vendedoresService;
        private DepartamentosService _departamentosService;
        //Construtor
        public VendedoresController(VendedoresService vendedoresService, DepartamentosService departamentosService)
        {
            _vendedoresService = vendedoresService;
            _departamentosService = departamentosService;
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
            //Serão passados a View 'Criar' os dados do modelo de visão 'VendedorFormViewModel'
            var departamentos = _departamentosService.FindAll();
            var ViewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(ViewModel);
        }

        //Método POST para "Criar"
        [HttpPost]
        //Para previnir ataques do tipo CSRF (validação maliciosa)
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Vendedor vendedor)
        {
           
            _vendedoresService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Deletar(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _vendedoresService.FindById(id.Value);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletar(int id)
        {
            _vendedoresService.Remove(id);
            return RedirectToAction("Index");
        }
        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _vendedoresService.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


    }
}
