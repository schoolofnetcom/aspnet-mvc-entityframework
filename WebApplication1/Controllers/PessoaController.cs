using Service.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PessoaController : Controller
    {
        //
        // GET: /Pessoa/
        public ActionResult Index()
        {
            ViewBag.Mensagem = "Minha primeira View";
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Pessoa model)
        {
            ModelState.Remove("Codigo");

            if (ModelState.IsValid)
            {
                PessoaService srv = new PessoaService();
                srv.Salvar(model);

                return View("List", srv.Listar());
            }
            else
                return View(model);
        }

        public ActionResult List()
        {
            PessoaService srv = new PessoaService();
            return View(srv.Listar());
        }

        public ActionResult Edit(int id)
        {
            var srv = new PessoaService();
            return View("Create", srv.Obter(id));
        }

        [HttpPost]
        public ActionResult Edit(Pessoa model)
        {
            if (ModelState.IsValid)
            {
                PessoaService srv = new PessoaService();
                srv.Salvar(model);

                return View("List", srv.Listar());
            }
            else
                return View("Create", model);
        }

        public ActionResult Delete(int id)
        {
            PessoaService srv = new PessoaService();
            srv.Deletar(id);

            return View("List", srv.Listar());
        }
	}
}