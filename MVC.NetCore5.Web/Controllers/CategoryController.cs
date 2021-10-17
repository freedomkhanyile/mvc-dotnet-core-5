using Microsoft.AspNetCore.Mvc;
using MVC.NetCore5.Web.Data;
using MVC.NetCore5.Web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.NetCore5.Web.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _context.Category;
            return View(categories);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                _context.Category.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);

        }

        // GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }

            var itemToUpdate = _context.Category.Find(id);
            if(itemToUpdate == null)
            {
                return NotFound();
            }
            return View(itemToUpdate);
        }

        // POST EDIT

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                _context.Category.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);

        }

        // GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }

            var itemToDelete = _context.Category.Find(id);
            if (itemToDelete == null)
            {
                return NotFound();
            }
            return View(itemToDelete);
        }

        // GET - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var itemToDelete = _context.Category.Find(id);

            if (itemToDelete == null)
            {
                return NotFound();
            }
            _context.Category.Remove(itemToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
