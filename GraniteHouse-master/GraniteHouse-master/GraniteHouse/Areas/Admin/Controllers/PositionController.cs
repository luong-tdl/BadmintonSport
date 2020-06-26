using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse.Data;
using Microsoft.AspNetCore.Mvc;
using GraniteHouse.Data;
using GraniteHouse.Models;
using GraniteHouse.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using GraniteHouse.Utility;
using Microsoft.AspNetCore.Authorization;

namespace GraniteHouse.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class PositionController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PositionController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.PositionEmployees.ToListAsync());
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PositionEmployee positionEmployee)
        {
            if (ModelState.IsValid)
            {

                _db.Add(positionEmployee);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(positionEmployee);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vitri = await _db.PositionEmployees.FindAsync(id);
            if (vitri == null)
            {
                return NotFound();
            }
            return View(vitri);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PositionEmployee vitri)
        {
            if (ModelState.IsValid)
            {
                _db.Update(vitri);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(vitri);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vitri = await _db.PositionEmployees.FindAsync(id);
            if (vitri == null)
            {
                return NotFound();
            }
            return View(vitri);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vitri = await _db.PositionEmployees.FindAsync(id);
            if (vitri == null)
            {
                return NotFound();
            }
            return View(vitri);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vitri = await _db.PositionEmployees.FindAsync(id);
            _db.PositionEmployees.Remove(vitri);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }
}