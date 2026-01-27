using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services.Contacts;
using InventoryManagementSystem.Data;

namespace InventoryManagementSystem.Services.Implementations
{
    public class ProductService : IProductReader, IProductWriter
    {
        private readonly IMSDBContext _context;

        public ProductService(IMSDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return await _context.Product.Include(p => p.Categories).Include(p => p.Suppliers).ToListAsync();
        }
        
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Product.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var exists = await _context.Product.AnyAsync(p => p.Id == product.Id);
            if (!exists) return false;

            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductByIdAsync(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null) return false;

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
