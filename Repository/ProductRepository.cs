using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementSystem.Models.Product;

namespace InventoryManagementSystem.Repository
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                CategoryId = 1,
                Description = "Laptop Description",
                Name = "Laptop",
                Price = 100000,
                Quantity = 5
            },
            new Product
            {
                Id = 2,
                CategoryId = 2,
                Description = "Mouse Description",
                Name = "Mouse",
                Price = 100000,
                Quantity = 5
            },
            new Product
            {
                Id = 3,
                CategoryId = 3,
                Description = "Keyboard Description",
                Name = "Keyboard",
                Price = 100000,
                Quantity = 5
            },
        };

        public static List<Product> GetAll()
        {
            return _products;
        }

        public static Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public static void Add(Product product)
        {
            _products.Add(product);
        }

        public static void Update(Product product)
        {
            var existingProduct = GetById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
            }
        }
        public static void Delete(int id)
        {
            var existingProduct = GetById(id);
            if (existingProduct != null)
            {
                _products.Remove(existingProduct);
            }
        }
    }
}