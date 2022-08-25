using jago.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jago.domain.Interfaces.Repositories
{
    public interface IPassengerRepository : IRepository<Passenger>
    {
        IQueryable<Passenger> GetPax();
    }
}
