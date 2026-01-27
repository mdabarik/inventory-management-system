using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services.Contacts;
using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
    private readonly IProductReader _reader;
    private readonly IProductWriter _writer;

    public ProductController(IProductReader reader, IProductWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    [HttpGet("")]
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var products = await _reader.GetAllProductAsync();
        return View(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var product = await _reader.GetProductByIdAsync(id);
        if (product == null) return NotFound();
        return View(product);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(Product product)
    {
        if (ModelState.IsValid)
        {
            await _writer.AddProductAsync(product);
            return RedirectToAction("Index");
        }
        return View(product);
    }

    [HttpPost("Edit")]
    public async Task<IActionResult> Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            var updated = await _writer.UpdateProductAsync(product);
            if (!updated) return NotFound();
            return RedirectToAction("Index");
        }
        return View(product);
    }

    [HttpPost("DeleteConfirmed/{id}")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var deleted = await _writer.DeleteProductByIdAsync(id);
        if (!deleted) return NotFound();
        return RedirectToAction("Index");
    }
}
