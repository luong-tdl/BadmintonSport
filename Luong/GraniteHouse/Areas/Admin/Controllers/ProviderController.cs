using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse.Data;
using GraniteHouse.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraniteHouse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProviderController : Controller
    {       
        private readonly ApplicationDbContext _db;
        public ProviderController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Providers.ToList());
        }
        //GET Create Action Method
        public IActionResult Create()
        {
            return View();
        }

        //POST Create action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Provider provider)
        {
            if (ModelState.IsValid)
            {
                _db.Add(provider);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(provider);
        }
        //GET Edit Action Method
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provider = await _db.Providers.FindAsync(id);
            if (provider == null)
            {
                return NotFound();
            }

            return View(provider);
        }

        //POST Edit action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Provider provider)
        {
            if (id != provider.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(provider);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(provider);
        }
        //GET Details Action Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provider = await _db.Providers.FindAsync(id);
            if (provider == null)
            {
                return NotFound();
            }

            return View(provider);
        }
        //GET Delete Action Method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provider = await _db.Providers.FindAsync(id);
            if (provider == null)
            {
                return NotFound();
            }

            return View(provider);
        }

        //POST Delete action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var provider = await _db.Providers.FindAsync(id);
            _db.Providers.Remove(provider);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}