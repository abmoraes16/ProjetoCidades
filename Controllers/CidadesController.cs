using Microsoft.AspNetCore.Mvc;
using ProjetoCidades.Models;
using ProjetoCidades.Repositorio;

namespace ProjetoCidades.Controllers
{
    public class CidadesController:Controller
    {
        Cidade cidade = new Cidade();
        CidadeRep objCidadeRep = new CidadeRep();
        public IActionResult Index(){
            var lista = objCidadeRep.Listar();
            
            return View(lista);
        }

        public IActionResult CidadesEstados(){
            var lista = cidade.ListarCidades();
            return View(lista);
        }

        public IActionResult TodosDados(){
            var lista = cidade.ListarCidades();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastrar(){
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([Bind]Cidade cidade){
            objCidadeRep.Cadastrar(cidade);

            return RedirectToAction("Index");
        }
    }
}