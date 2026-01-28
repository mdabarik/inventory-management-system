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
    public class SupplierService : ISupplierReader
    {
        private readonly IMSDBContext _context;
        public SupplierService(IMSDBContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Supplier>> GetAllSupplierAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

    }
}