using HPlusSportsAPI.Contracts;
using HPlusSportsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private H_Plus_SportsContext db;

        public OrderRepository(H_Plus_SportsContext context)
        {
            db = context;
        }

        public IEnumerable<Order> GetAll() => db.Order;

        public void Add(Order item)
        {
            db.Order.Add(item);
            db.SaveChanges();
        }

        public Order Find(int key) => db.Order.Include(order => order.OrderItem).Include(order => order.Customer).Single(a => a.OrderId == key);

        public Order Remove(int key)
        {
            Order item;
            item = db.Order.Single(a => a.OrderId == key);
            db.Order.Remove(item);
            db.SaveChanges();
            return item;
        }

        public void Update(Order item)
        {
            db.Order.Update(item);
            db.SaveChanges();
        }
    }
}