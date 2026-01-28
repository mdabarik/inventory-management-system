using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services.Contacts;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services.Implementations
{

    public class CategoryService : ICategoryReader, ICategoryWriter
    {
        private readonly IMSDBContext _context;
        public CategoryService(IMSDBContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> SearchCategoryAsync(string searchText)
        {
            IQueryable<Category> query = _context.Categories;
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query = query.Where(c => c.Name.Contains(searchText));
            }
            return await query.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            var exists = await _context.Categories.AnyAsync(p => p.Id == category.Id);
            if (!exists) return false;

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteCategoryByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
        
    }
}