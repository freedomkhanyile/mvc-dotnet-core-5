using Microsoft.AspNetCore.Mvc;
using MVC.NetCore5.Web.Data;
using MVC.NetCore5.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.NetCore5.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Book> books = _context.Book;
            return View(books);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book model)
        {
            _context.Book.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }

            var itemToUpdate = _context.Book.Find(id);

            if (itemToUpdate == null)
            {
                return NotFound();
            }

            return View(itemToUpdate);
        }

        // POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book model)
        {
            if (ModelState.IsValid)
            {
                _context.Book.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }

            var itemToDelete = _context.Book.Find(id);

            if (itemToDelete == null)
            {
                return NotFound();
            }

            return View(itemToDelete);
        }

        // POST DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var itemToDelete = _context.Book.Find(id);

            if (itemToDelete == null)
            {
                return NotFound();
            }
            
            _context.Book.Remove(itemToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
