using GraniteHouse.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteHouse.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class News : Controller
    {
        private readonly ApplicationDbContext _db;

        public News (ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Chuyen()
        {

            return View();
        }
        public IActionResult timhieuvemoncaulong()
        {

            return View();
        }
        public IActionResult votcaulongyonexvoltric1dgnewcayvotthienconggiatot()
        {

            return View();
        }
        public IActionResult kythuatchoicaulong()
        {

            return View();
        }
        public IActionResult tapdanhcaulong()
        {

            return View();
        }
        public IActionResult daydanvotyonex()
        {

            return View();
        }
        public IActionResult bangquanyonexcaulong()
        {

            return View();
        }
        public IActionResult phanbietmacodevamasanxuatvotcaulong()
        {

            return View();
        }
        public IActionResult sancaulongt793quan7()
        {

            return View();
        }
        public IActionResult shopcaulongbienhoavnbsports()
        {

            return View();
        }
        public IActionResult sancaulonglongvienquan7()
        {

            return View();
        }
        public IActionResult sancaulongquan7()
        {

            return View();
        }
    }
}
