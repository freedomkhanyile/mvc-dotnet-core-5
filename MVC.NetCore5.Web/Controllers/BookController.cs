using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.NetCore5.Web.Data;
using MVC.NetCore5.Web.Data.Extensions;
using MVC.NetCore5.Web.Data.Models;
using MVC.NetCore5.Web.Data.Services.Contracts;
using MVC.NetCore5.Web.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MVC.NetCore5.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _service;

        private readonly ILogger<BookController> _logger;

        public BookController(
            IBookService service,
            ILogger<BookController> logger = null
        )
        {
            _service = service;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var books = _service.GetAll();
            _logger
                .LogInformation($"{books.ToList().Count} returned successfully!");
            return View(books);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookViewModel model)
        {
            var book = await _service.CreateBook(model);
            _logger
                .LogInformation($"Book with name :{book.Name} was created successfully");
            return RedirectToAction("Index");
        }

        // GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var itemToUpdate = _service.GetById((int) id);
            if (itemToUpdate == null)
            {
                return NotFound();
            }

            return View(itemToUpdate.ToUpdateViewModel());
        }

        // POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = await _service.UpdateBook(model.Id, model);
                _logger
                    .LogInformation($"Book with name :{book.Name} was updated successfully");

                return RedirectToAction("Index");
            }
            return View(model);
        }

        // // GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var itemToDelete = _service.GetById((int) id);

            if (itemToDelete == null)
            {
                return NotFound();
            }

            return View(itemToDelete);
        }

        // // POST DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            var isDeleted = await _service.DeleteBook(id);
            if (isDeleted)
            {
                return RedirectToAction("Index");
            } else {
                var itemToDelete = _service.GetById(id);
                return View(itemToDelete);
            }
        }
    }
}
