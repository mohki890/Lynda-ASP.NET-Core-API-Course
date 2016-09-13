using HPlusSportsAPI.Contracts;
using HPlusSportsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private H_Plus_SportsContext db;

        public CustomerRepository(H_Plus_SportsContext context)
        {
            db = context;
        }

        public IEnumerable<Customer> GetAll() => db.Customer;

        public void Add(Customer item)
        {
            db.Customer.Add(item);
            db.SaveChanges();
        }

        public Customer Find(int key) => db.Customer.Include(customer => customer.Order).Single(a => a.CustomerId == key);

        public Customer Remove(int key)
        {
            Customer item;
            item = db.Customer.Single(a => a.CustomerId == key);
            db.Customer.Remove(item);
            db.SaveChanges();
            return item;
        }

        public void Update(Customer item)
        {
            try
            {
                db.Customer.Update(item);
                db.SaveChanges();
            }
            catch (Exception e)
            {
            }
        }
    }
}