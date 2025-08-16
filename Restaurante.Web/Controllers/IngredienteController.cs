using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Web.Data;
using Restaurante.Web.Models.Ingrediente;

namespace Restaurante.Web.Controllers
{
    public class IngredienteController : Controller
    {
        public readonly RestauranteDbContext _context;

        public IngredienteController(RestauranteDbContext context)
        {
            _context = context;
        }

        // GET: IngredienteController
        public ActionResult Index()
        {
            return View(_context.Ingredientes.ToList());
        }

        // GET: IngredienteController/Details/5
        public ActionResult Details(Guid id)
        {
            var ingrediente = _context.Ingredientes.FirstOrDefault(i => i.Id.Equals(id));
            return View(ingrediente);
        }

        // GET: IngredienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngredienteController/Create
        [HttpPost]
        public ActionResult Create(Ingrediente createIngredienteViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(createIngredienteViewModel);
                }

                var ingredienteExistente = _context.Ingredientes.
                    FirstOrDefault(x => 
                        x.Nome.Equals(createIngredienteViewModel.Nome) && 
                        x.Ativo);

                if (ingredienteExistente != null)
                {
                    ModelState.AddModelError("Nome", "Já existe um ingrediente com esse nome.");
                    return View(createIngredienteViewModel);
                }

                _context.Ingredientes.Add(new Ingrediente
                {
                    Id = Guid.NewGuid(),
                    Nome = createIngredienteViewModel.Nome,
                    Ativo = true
                });

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IngredienteController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var ingrediente = _context.Ingredientes.FirstOrDefault(i => i.Id.Equals(id));
            return View(ingrediente);
        }

        // POST: IngredienteController/Edit/5
        [HttpPost]
        public ActionResult Edit(Ingrediente ingrediente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(ingrediente);
                }

                var ingredienteExistente = _context.Ingredientes.
                    FirstOrDefault(x =>
                        x.Nome.Equals(ingrediente.Nome) &&
                        x.Ativo);

                if (ingredienteExistente != null)
                {
                    ModelState.AddModelError("Nome", "Já existe um ingrediente com esse nome.");
                    return View(ingrediente);
                }

                _context.Update(ingrediente);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IngredienteController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var ingrediente = _context.Ingredientes.
                    FirstOrDefault(x =>
                        x.Id.Equals(id));

            return View(ingrediente);
        }

        // POST: IngredienteController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteIngrediente(Guid id)
        {
            try
            {
                var ingredienteExistente = _context.Ingredientes.
                    FirstOrDefault(x =>
                        x.Id.Equals(id) &&
                        x.Ativo);

                ingredienteExistente.Ativo = false;

                _context.Update(ingredienteExistente);

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
