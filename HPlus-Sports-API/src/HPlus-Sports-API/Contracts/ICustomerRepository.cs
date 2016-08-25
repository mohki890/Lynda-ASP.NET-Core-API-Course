using HPlusSportsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Contracts
{
    public interface ICustomerRepository
    {
        void Add(Customer item);

        IEnumerable<Customer> GetAll();

        Customer Find(int key);

        Customer Remove(int key);

        void Update(Customer item);
    }
}