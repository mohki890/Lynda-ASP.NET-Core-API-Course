using HPlusSportsAPI.Contracts;
using HPlusSportsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Repositories
{
    public class SalespersonRepository : ISalespersonRepository
    {
        private H_Plus_SportsContext db;

        public SalespersonRepository(H_Plus_SportsContext context)
        {
            db = context;
        }

        public IEnumerable<Salesperson> GetAll() => db.Salesperson;

        public void Add(Salesperson item)
        {
            db.Salesperson.Add(item);
            db.SaveChanges();
        }

        public Salesperson Find(int key) => db.Salesperson.Include(salesperson => salesperson.Order).SingleOrDefault(a => a.SalespersonId == key);

        public Salesperson Remove(int key)
        {
            Salesperson item;
            item = db.Salesperson.Single(a => a.SalespersonId == key);
            db.Salesperson.Remove(item);
            db.SaveChanges();
            return item;
        }

        public void Update(Salesperson item)
        {
            db.Salesperson.Update(item);
            db.SaveChanges();
        }
    }
}