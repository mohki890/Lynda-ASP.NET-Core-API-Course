using HPlusSportsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Contracts
{
    public interface IOrderItemRepository
    {
        void Add(OrderItem item);

        IEnumerable<OrderItem> GetAll();

        OrderItem Find(int key);

        OrderItem Remove(int key);

        void Update(OrderItem item);
    }
}