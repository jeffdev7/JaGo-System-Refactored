using jago.domain.Entities;
using jago.domain.Interfaces.Repositories;
using jago.Infrastructure.DBConfiguration;

namespace jago.Infrastructure.Repositories
{
    public class PassengerRepository : Repository<Passenger>, IPassengerRepository
    {
        public PassengerRepository(ApplicationContext context) : base(context)
        {
        }
        public IQueryable<Passenger> GetPax()
        {
            return Db.Passengers;
        }
    }
}
