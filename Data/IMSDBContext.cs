using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Data
{
    public class IMSDBContext : DbContext
    {
        public IMSDBContext(DbContextOptions<IMSDBContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
