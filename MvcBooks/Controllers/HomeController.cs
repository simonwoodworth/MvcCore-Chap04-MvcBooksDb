using Microsoft.AspNetCore.Mvc;
using MvcBooks.Models;

namespace MvcBooks.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        public IActionResult Index()
        {
            DB db = DB.Restore();
            ViewBag.Cats = db.cats;
            return View();
        }

        // GET: /Home/Books
        public IActionResult Books()
        {
            DB db = DB.Restore();
            ViewBag.Books = db.books;
            return View();
        }

        // GET: /Home/BooksByCat
        public IActionResult BooksByCat()
        {
            DB db = DB.Restore();
            ViewBag.DB = db;
            return View();
        }

        // GET: /Home/Save
        public string Save()
        {
            DB db = DB.Restore();
            return db.Save();
        }

        // GET: /Home/AddCat
        public IActionResult AddCat()
        {
            return View();
        }

        // POST: /Home/AddCat
        [HttpPost]
        public string AddCat(Category cat)
        {
            string msg = DB.AddCategory(cat);
            return msg;
        }
    }
}
