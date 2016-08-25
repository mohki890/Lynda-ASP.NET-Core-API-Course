using HPlusSportsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Contracts
{
    public interface IOrderRepository
    {
        void Add(Order item);

        IEnumerable<Order> GetAll();

        Order Find(int key);

        Order Remove(int key);

        void Update(Order item);
    }
}