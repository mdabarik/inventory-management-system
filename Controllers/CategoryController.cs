using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services.Contacts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InventoryManagementSystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryReader _reader;
        private readonly ICategoryWriter _writer;
        public CategoryController(ILogger<CategoryController> logger, ICategoryReader reader, ICategoryWriter writer)
        {
            _logger = logger;
            _reader = reader;
            _writer = writer;
        }
        public async Task<IActionResult> Index(string searchText)
        {
            var categories = await _reader.SearchCategoryAsync(searchText);
            return View(categories);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _writer.AddCategoryAsync(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _reader.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var updated = await _writer.UpdateCategoryAsync(category);
                if (!updated) return NotFound();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _writer.DeleteCategoryByIdAsync(id);
            if (!deleted) return NotFound();
            return RedirectToAction("Index");
        }

    }
}