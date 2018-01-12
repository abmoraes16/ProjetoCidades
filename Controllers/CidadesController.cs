using System;
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
        //Get - Retornando dados para View
        [HttpGet]
        public IActionResult Cadastrar(){
            return View();
        }

        //Post - Postando dados no banco
        [HttpPost]
        public IActionResult Cadastrar([Bind]Cidade cidade){
            objCidadeRep.Cadastrar(cidade);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int Id){
            var cidadeSelecionada = objCidadeRep.Consultar(Id);
            return View(cidadeSelecionada);
        }

        [HttpPost]
        public IActionResult Editar([Bind]Cidade cidade){
            objCidadeRep.Editar(cidade);

            return RedirectToAction("Index");
        }
        public IActionResult Excluir(Cidade cidade){
            objCidadeRep.Excluir(cidade.Id);
            TempData["mensagem"]="Cidade excluida!";
            TempData["amanda"]="Meu nome é Amanda";
            return RedirectToAction("Index");
        }

        public IActionResult Detalhes(int id){
            var cidadeSelecionada = objCidadeRep.Consultar(id);
            return View(cidadeSelecionada);
        }

    }
}