using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse.Data;
using GraniteHouse.Models;
using GraniteHouse.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraniteHouse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public EmployeeViewModel EmployeeVM { get; set; }
        public EmployeesController(ApplicationDbContext db)
        {
            _db = db;
            EmployeeVM = new EmployeeViewModel()
            {
                PositionEmployees = _db.PositionEmployees.ToList(),
                Employee = new Models.Employee()
            };
        }
        public async Task<IActionResult> Index()
        {
            var employees = _db.Employees.Include(m => m.PositionEmployee);
            return View(await employees.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(EmployeeVM);
        }

        //Post : Products Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            if (!ModelState.IsValid)
            {
                return View(EmployeeVM);
            }

            _db.Employees.Add(EmployeeVM.Employee);
            await _db.SaveChangesAsync();

            //Image being saved

            //string webRootPath = _hostingEnvironment.WebRootPath;
            //var files = HttpContext.Request.Form.Files;

            var productsFromDb = _db.Products.Find(EmployeeVM.Employee.Id);

            //if (files.Count != 0)
            //{
            //    //Image has been uploaded
            //    var uploads = Path.Combine(webRootPath, SD.ImageFolder);
            //    var extension = Path.GetExtension(files[0].FileName);

            //    using (var filestream = new FileStream(Path.Combine(uploads, ProductsVM.Products.Id + extension), FileMode.Create))
            //    {
            //        files[0].CopyTo(filestream);
            //    }
            //    productsFromDb.Image = @"\" + SD.ImageFolder + @"\" + ProductsVM.Products.Id + extension;
            //}
            //else
            //{
            //    //when user does not upload image
            //    var uploads = Path.Combine(webRootPath, SD.ImageFolder + @"\" + SD.DefaultProductImage);
            //    System.IO.File.Copy(uploads, webRootPath + @"\" + SD.ImageFolder + @"\" + ProductsVM.Products.Id + ".png");
            //    productsFromDb.Image = @"\" + SD.ImageFolder + @"\" + ProductsVM.Products.Id + ".png";
            //}
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmployeeVM.Employee = await _db.Employees.Include(m => m.PositionEmployee).SingleOrDefaultAsync(m => m.Id == id);

            if (EmployeeVM.Employee == null)
            {
                return NotFound();
            }

            return View(EmployeeVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //string webRootPath = _hostingEnvironment.WebRootPath;
            Employee employees = await _db.Employees.FindAsync(id);

            if (employees == null)
            {
                return NotFound();
            }
            else
            {
                //var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                //var extension = Path.GetExtension(products.Image);

                //if (System.IO.File.Exists(Path.Combine(uploads, products.Id + extension)))
                //{
                //    System.IO.File.Delete(Path.Combine(uploads, products.Id + extension));
                //}
                _db.Employees.Remove(employees);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
        }
    }
}