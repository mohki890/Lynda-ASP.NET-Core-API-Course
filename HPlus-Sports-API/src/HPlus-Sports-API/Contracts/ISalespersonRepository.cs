using HPlusSportsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Contracts
{
    public interface ISalespersonRepository
    {
        void Add(Salesperson item);

        IEnumerable<Salesperson> GetAll();

        Salesperson Find(int key);

        Salesperson Remove(int key);

        void Update(Salesperson item);
    }
}