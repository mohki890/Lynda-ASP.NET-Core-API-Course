using HPlusSportsAPI.Contracts;
using HPlusSportsAPI.Models;
using System.Collections.Generic;

namespace HPlusSportsAPI.Services
{
    public class CustomerService : IService<Customer>
    {
        private H_Plus_SportsContext ds;

        public CustomerService(H_Plus_SportsContext d)
        {
            ds = d;
        }

        public IEnumerable<Customer> Get()
        {
            return ds.Customer;
        }
    }
}