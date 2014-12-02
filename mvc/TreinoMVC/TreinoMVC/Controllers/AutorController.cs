using System.Web.Mvc;
using TreinoMVC.Modelo;
using TreinoMVC.Service;

namespace TreinoMVC.Controllers
{
    public class AutorController : Controller
    {
        AutorServ servAutor = new AutorServ();

        // GET: Autor
        public ActionResult Index()
        {
            var lista = servAutor.ListarTodos();
            return View(lista);
        }

        // GET: Autor/Details/5
        public ActionResult Details(int id)
        {
            var autor = servAutor.BuscarPorId(id);
            return View(autor);
        }

        // GET: Autor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Autor autor)
        {
            if (ModelState.IsValid)
            {
                servAutor.Salvar(autor);
                return RedirectToAction("Index");
            }
            return View(autor);
        }

        // GET: Autor/Edit/5
        public ActionResult Edit(int id)
        {
            var autor = servAutor.BuscarPorId(id);
            if (autor == null)
            {
                return HttpNotFound();
            }

            return View(autor);
        }

        // POST: Autor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Autor autor)
        {
            if (ModelState.IsValid)
            {
                servAutor.Salvar(autor);
                return RedirectToAction("Index");
            }
            return View(autor);
        }

        // GET: Autor/Delete/5
        public ActionResult Delete(int id)
        {
            var autor = servAutor.BuscarPorId(id);
            if (autor == null)
            {
                return HttpNotFound();
            }

            return View(autor);
        }

        // POST: Autor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmado(int id)
        {
            servAutor.Excluir(id);
            return RedirectToAction("Index");

        }
    }
}
