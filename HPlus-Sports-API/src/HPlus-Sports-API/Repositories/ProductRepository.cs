using HPlusSportsAPI.Contracts;
using HPlusSportsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private H_Plus_SportsContext db;

        public ProductRepository(H_Plus_SportsContext context)
        {
            db = context;
        }

        public IEnumerable<Product> GetAll() => db.Product;

        public void Add(Product item)
        {
            db.Product.Add(item);
            db.SaveChanges();
        }

        public Product Find(string key) => db.Product.Include(product => product.OrderItem).Single(a => a.ProductId == key);

        public Product Remove(string key)
        {
            Product item;
            item = db.Product.Single(a => a.ProductId == key);
            db.Product.Remove(item);
            db.SaveChanges();
            return item;
        }

        public void Update(Product item)
        {
            db.Product.Update(item);
            db.SaveChanges();
        }
    }
}