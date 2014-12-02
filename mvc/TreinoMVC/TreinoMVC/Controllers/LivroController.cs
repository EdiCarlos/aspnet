using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinoMVC.Modelo;
using TreinoMVC.Service;

namespace TreinoMVC.Controllers
{
    public class LivroController : Controller
    {
        LivroServ servLivro = new LivroServ();
        // GET: Livro
        public ActionResult Index()
        {
            var lista = servLivro.ListarTodos();
            return View(lista);
        }

        // GET: Livro/Details/5
        public ActionResult Details(int id)
        {
            var livro = servLivro.BuscarPorId(id);
            return View(livro);
        }

        // GET: Livro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Livro livro)
        {
            if (ModelState.IsValid)
            {
                servLivro.Salvar(livro);
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        // GET: Livro/Edit/5
        public ActionResult Edit(int id)
        {
            var livro = servLivro.BuscarPorId(id);
            return View(livro);
        }

        // POST: Livro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Livro livro)
        {
            if (ModelState.IsValid)
            {
                servLivro.Salvar(livro);
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        // GET: Livro/Delete/5
        public ActionResult Delete(int id)
        {
            var livro = servLivro.BuscarPorId(id);
            return View(livro);
        }

        // POST: Livro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmado(int id)
        {
            servLivro.Excluir(id);
            return RedirectToAction("Index");

        }
    }
}
