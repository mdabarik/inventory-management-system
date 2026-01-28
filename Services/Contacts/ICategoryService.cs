using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services.Contacts
{
    public interface ICategoryReader
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task<List<Category>> SearchCategoryAsync(string searchText);
    }

    public interface ICategoryWriter
    {
        Task<Category> AddCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryByIdAsync(int id);
    }

    
}