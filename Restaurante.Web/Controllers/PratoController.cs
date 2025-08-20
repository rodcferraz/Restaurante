using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurante.Web.Data;
using Restaurante.Web.Models;

namespace Restaurante.Web.Controllers
{
    public class PratoController : Controller
    {
        private readonly RestauranteDbContext _context;

        public PratoController(RestauranteDbContext context)
        {
            _context = context;
        }

        // GET: PratoController
        public ActionResult Index()
        {
            return View(_context.Pratos.Where(x => x.Ativo).ToList());
        }

        // GET: PratoController/Details/5
        public ActionResult Details(Guid id)
        {
            var pratos = _context.Pratos
                .Include(x => x.Ingredientes)
                .FirstOrDefault(i => i.Id.Equals(id));

            ViewBag.Ingredientes = pratos.Ingredientes;

            return View(pratos);
        }

        // GET: PratoController/Create
        public ActionResult Create()
        {
            var ingredientes = _context.Ingredientes.Where(x => x.Ativo);
            ViewBag.Ingredientes = ingredientes.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Nome }).ToList();

            return View();
        }

        // POST: PratoController/Create
        [HttpPost]
        public ActionResult Create(PratoViewModel pratoViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(pratoViewModel);
                }

                var pratoExistente = _context.Pratos.
                    FirstOrDefault(x =>
                        x.Nome.Equals(pratoViewModel.Nome) &&
                        x.Ativo);

                var ingredientes = _context.Ingredientes
                    //.Include(x => x.Pratos)
                    .Where(x => pratoViewModel.Ingredientes.Contains(x.Id))
                    .ToList();

                if (pratoExistente != null)
                {
                    ModelState.AddModelError("Nome", "Já existe um prato com esse nome.");
                    return View(pratoViewModel);
                }

                var prato = new Prato
                {
                    Id = Guid.NewGuid(),
                    Nome = pratoViewModel.Nome,
                    Descricao = pratoViewModel.Descricao,
                    Ingredientes = ingredientes,
                    Ativo = true
                };

                //ingredientes.ForEach(x => x.Pratos.Add(prato));

                _context.Pratos.Add(prato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Details), new { id = prato.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: PratoController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var prato = _context.Pratos.FirstOrDefault(i => i.Id.Equals(id));

            ViewBag.Ingredientes = _context.Ingredientes
                .Where(x => x.Ativo)
                .Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Nome })
                .ToList();

            var model = new PratoViewModel
            {
                Id = id,
                Nome = prato.Nome,
                Descricao = prato.Descricao,
                Ingredientes = _context.Ingredientes.Select(x => x.Id).ToList()
            };

            return View(model);
        }

        // POST: PratoController/Edit/5
        [HttpPost]
        public ActionResult Edit(PratoViewModel pratoViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(pratoViewModel);
                }

                var pratoExistente = _context.Pratos.Any(x =>
                        x.Nome.Equals(pratoViewModel.Nome) &&
                        x.Id != pratoViewModel.Id &&
                        x.Ativo);

                if (pratoExistente)
                {
                    ModelState.AddModelError("Nome", "Já existe um ingrediente com esse nome.");
                    return View(pratoViewModel);
                }

                var prato = _context.Pratos.Include(x => x.Ingredientes).FirstOrDefault(x => x.Id == pratoViewModel.Id);

                var ingredientes = _context.Ingredientes
                    .Where(x => pratoViewModel.Ingredientes.Contains(x.Id))
                    .ToList();

                prato.Nome = pratoViewModel.Nome;
                prato.Descricao = pratoViewModel.Descricao;
                prato.Ingredientes = ingredientes;

                _context.Pratos.Update(prato);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PratoController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var prato = _context.Pratos.
                    FirstOrDefault(x =>
                        x.Id.Equals(id));
            return View(prato);
        }

        // POST: PratoController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePrato(Guid id)
        {
            try
            {
                var pratoExistente = _context.Pratos.
                   FirstOrDefault(x =>
                       x.Id.Equals(id) &&
                       x.Ativo);

                pratoExistente.Ativo = false;

                _context.Update(pratoExistente);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
