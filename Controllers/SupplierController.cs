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
    public class SupplierController: Controller
    {
        private readonly ILogger<SupplierController> _logger;
        private readonly ISupplierReader _reader;
        private readonly ISupplierWriter _writer;
        public SupplierController(ILogger<SupplierController> logger, ISupplierReader reader, ISupplierWriter writer)
        {
            _logger = logger;
            _reader = reader;
            _writer = writer;
        }

        public async Task<IActionResult> Index(string searchText)
        {
            var suppliers = await _reader.SearchSupplierAsync(searchText);
            return View(suppliers);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                await _writer.AddSupplierAsync(supplier);
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var supplier = await _reader.GetSupplierByIdAsync(id);
            if (supplier == null) return NotFound();

            return View(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var updated = await _writer.UpdateSupplierAsync(supplier);
                if (!updated) return NotFound();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _writer.DeleteSupplierByIdAsync(id);
            if (!deleted) return NotFound();
            return RedirectToAction("Index");
        }
     }
}