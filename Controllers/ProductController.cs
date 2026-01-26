using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace InventoryManagementSystem.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMSDBContext _context;

        public ProductController(ILogger<ProductController> logger, IMSDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            
            return View(products);
        }

        public IActionConstraint Create()
            PopulateDropdown();
            return View();
        }

        private void PopulateDropdown()
        {
            var categories = new List<Category
        }

        /*
        // CREATE: Show form
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE: Save new product
        [HttpPost("Create")]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // UPDATE: Show edit form
        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // UPDATE: Save changes
        [HttpPost("Edit/{id}")]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // DELETE: Show confirmation
        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // DELETE: Confirm and remove
        [HttpPost("Delete/{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        */

        // ERROR
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}
