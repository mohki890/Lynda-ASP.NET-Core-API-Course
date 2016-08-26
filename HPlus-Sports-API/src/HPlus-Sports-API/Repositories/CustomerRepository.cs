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
        private H_Plus_SportsContext db = new H_Plus_SportsContext();

        public CustomerRepository()
        {
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
            db.Customer.Update(item);
            db.SaveChanges();
        }
    }
}