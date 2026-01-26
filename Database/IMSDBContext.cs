using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Database
{
    public class IMSDBContext : DbContext
    {
        public IMSDBContext(DbContextOptions<IMSDBContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
