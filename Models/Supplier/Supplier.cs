using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models.Supplier
{
    public class Supplier
    {
        public int Id { set; get; }
        public string Name { set; get; } = string.Empty;
        public string Country { set; get; } = string.Empty;
        public string ContactInfo { set; get; } = string.Empty;
    }
}