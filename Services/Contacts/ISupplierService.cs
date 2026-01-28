using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services.Contacts
{
    public interface ISupplierReader
    {
        Task<IEnumerable<Supplier>> GetAllSupplierAsync();
        Task<List<Supplier>> SearchSupplierAsync(string searchText);
    }
    public interface ISupplierWriter
    {
        Task<Supplier> AddSupplierAsync(Supplier supplier);
        Task<bool> UpdateSupplierAsync(Supplier supplier);
        Task<bool> DeleteSupplierByIdAsync(int id);
    }

}