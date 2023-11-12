using BRSK_Test.Data;
using BRSK_Test.Data.Models;
using BRSK_Test.Data.Models.ModelGroup;
using BRSK_Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Policy;

namespace BRSK_Test.Controllers
{
    public class ModelController : Controller
    {
        private readonly DataContext _context;

        public ModelController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (_context.Models == null)
                return Problem("Entity set 'DataContext.Models'  is null.");
            else
                return View(_context.Brands.ToList().Select
                        (brand => new ModelGroup
                        {
                            Brand = brand,
                            Models = _context.Models.ToList().Where(model => model.Brand.Id == brand.Id).ToList()
                        })
                        );
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Brands = (await _context.Brands.ToListAsync())
                .Select(i => new SelectListItem(i.Name, i.Id.ToString()));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name, BrandId,Active")] Model model)
        {
        
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Models == null)
            {
                return NotFound();
            }

            var model = await _context.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            ViewBag.Brands = (await _context.Brands.ToListAsync())
                .Select(i => new SelectListItem(i.Name, i.Id.ToString()));
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name, BrandId,Active")] Model model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Models == null)
            {
                return NotFound();
            }

            var brand = await _context.Models
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Brands == null)
            {
                return Problem("Entity set 'DataContext.Models'  is null.");
            }
            var model = await _context.Models.FindAsync(id);
            if (model != null)
            {
                _context.Models.Remove(model);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelExists(int id)
        {
            return (_context.Models?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
