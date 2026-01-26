using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services.Contacts
{
    public interface IProductService 
    { 
        Task<IEnumerable<Product>> GetAllProductAsync(); 
        Task<Product?> GetProductByIdAsync(int id); 
        Task<Product> AddProductAsync(Product product); 
        Task<bool> UpdateProductAsync(Product product); 
        Task<bool> DeleteProductByIdAsync(int id); 
    }
}