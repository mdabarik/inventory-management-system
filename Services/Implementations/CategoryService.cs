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

    public class CategoryService : ICategoryReader
    {
        private readonly IMSDBContext _context;
        public CategoryService(IMSDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        
    }
}