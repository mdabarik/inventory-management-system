using System.Threading.Tasks;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services.Contacts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ProductController : Controller
{
    private readonly IProductReader _reader;
    private readonly IProductWriter _writer;
    private readonly ICategoryReader _creader;
    private readonly ISupplierReader _sreader;

    public ProductController(IProductReader reader, IProductWriter writer, ICategoryReader creader, ISupplierReader sreader)
    {
        _reader = reader;
        _writer = writer;
        _creader = creader;
        _sreader = sreader;
    }

    // public async Task<IActionResult> Index()
    // {
    //     var products = await _reader.GetAllProductAsync();
    //     return View(products);
    // }

    public async Task<IActionResult> Index(string searchText)
    {
        var products = await _reader.SearchProductsAsync(searchText);
        return View(products);
    }
    public async Task<IActionResult> Details(int id)
    {
        var product = await _reader.GetProductByIdAsync(id);
        if (product == null)
        {
            View("Error", "Something went wrong");
        }
        if (product == null) return NotFound();
        return View(product);
    }

    public async Task<IActionResult> Create()
    {
        await PopulateDropdown();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        if (ModelState.IsValid)
        {
            await _writer.AddProductAsync(product);
            return RedirectToAction("Index");
        }
        return View(product);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var product = await _reader.GetProductByIdAsync(id);
        if (product == null) return NotFound();

        await PopulateDropdownEdit(product.CategoryId, product.SupplierId);
        return View(product);
    }
    private async Task PopulateDropdownEdit(int? selectedCategoryId = null, int? selectedSupplierId = null)
    {
        var categories = await _creader.GetAllCategoryAsync();
        var suppliers = await _sreader.GetAllSupplierAsync();

        ViewBag.Categories = new SelectList(categories, "Id", "Name", selectedCategoryId);
        ViewBag.Suppliers = new SelectList(suppliers, "Id", "Name", selectedSupplierId);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product product)
    {
        await PopulateDropdown();
        if (ModelState.IsValid)
        {
            var updated = await _writer.UpdateProductAsync(product);
            if (!updated) return NotFound();
            return RedirectToAction("Index");
        }
        return View(product);
    }

    private async Task PopulateDropdown()
    {
        var suppliers =  await _sreader.GetAllSupplierAsync();
        var categories = await _creader.GetAllCategoryAsync();

        ViewBag.Categories = new SelectList(categories, "Id", "Name");
        ViewBag.Suppliers = new SelectList(suppliers, "Id", "Name");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _writer.DeleteProductByIdAsync(id);
        if (!deleted) return NotFound();
        return RedirectToAction("Index");
    }
}
