using HPlusSportsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Contracts
{
    public interface IProductRepository
    {
        void Add(Product item);

        IEnumerable<Product> GetAll();

        Product Find(int key);

        Product Remove(int key);

        void Update(Product item);
    }
}