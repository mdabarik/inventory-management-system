using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Models
{   
    [Table("Products")]

    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public int Quantity { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required]
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

    }
}
