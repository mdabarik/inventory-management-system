using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InventoryManagementSystem.Controllers
{
    public class SupplierController: Controller
    {
        private readonly ILogger<SupplierController> _logger;
        public SupplierController(ILogger<SupplierController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
     }
}