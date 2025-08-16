using Microsoft.AspNetCore.Mvc;

namespace Restaurante.Web.Controllers
{
    public class PratoController : Controller
    {
        // GET: PratoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PratoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PratoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PratoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PratoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PratoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PratoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PratoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
