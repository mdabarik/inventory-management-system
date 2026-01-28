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
    }
    
}