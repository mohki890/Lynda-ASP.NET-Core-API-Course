using HPlusSportsAPI.Contracts;
using HPlusSportsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private H_Plus_SportsContext db;

        public OrderItemRepository(H_Plus_SportsContext context)
        {
            db = context;
        }

        public IEnumerable<OrderItem> GetAll() => db.OrderItem;

        public void Add(OrderItem item)
        {
            db.OrderItem.Add(item);
            db.SaveChanges();
        }

        public OrderItem Find(int key) => db.OrderItem.Include(orderItem => orderItem.Order).Include(orderItem => orderItem.Product).Single(a => a.OrderItemId == key);

        public OrderItem Remove(int key)
        {
            OrderItem item;
            item = db.OrderItem.Single(a => a.OrderItemId == key);
            db.OrderItem.Remove(item);
            db.SaveChanges();
            return item;
        }

        public void Update(OrderItem item)
        {
            db.OrderItem.Update(item);
            db.SaveChanges();
        }
    }
}