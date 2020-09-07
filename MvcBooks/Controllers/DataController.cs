using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcBooks.Models;

namespace MvcBooks.Controllers
{
    public class DataController : Controller
    {
        // GET: /Home/
        public IActionResult Index()
        {
            DBPub db = new DBPub();
            ViewBag.Cats = db.GetCategories();
            return View();
        }
    }
}
