using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Data
{
    public class IMSDBContext : DbContext
    {
        public IMSDBContext(DbContextOptions<IMSDBContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
    }
}
