using GraniteHouse.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteHouse.Areas.Customer.Controllers
{
    //
    [Area("Customer")]
    public class Introduce : Controller
    {
        private readonly ApplicationDbContext _db;

        public Introduce(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
