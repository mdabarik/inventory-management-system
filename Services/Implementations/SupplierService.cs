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
    public class SupplierService : ISupplierReader, ISupplierWriter
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

        public async Task<Supplier?> GetSupplierByIdAsync(int id)
        {
            return await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Supplier>> SearchSupplierAsync(string searchText)
        {
            IQueryable<Supplier> query = _context.Suppliers;

            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(s =>
                    s.Name.Contains(searchText));
            }

            return await query.ToListAsync();
        }

        public async Task<Supplier> AddSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }
        public async Task<bool> UpdateSupplierAsync(Supplier supplier)
        {
            var exists = await _context.Suppliers.AnyAsync(p => p.Id == supplier.Id);
            if (!exists) return false;

            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteSupplierByIdAsync(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null) return false;

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}