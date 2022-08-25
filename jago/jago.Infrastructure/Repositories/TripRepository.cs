using jago.domain.Entities;
using jago.domain.Interfaces.Repositories;
using jago.domain.Model;
using jago.Infrastructure.DBConfiguration;

namespace jago.Infrastructure.Repositories
{
    public class TripRepository : Repository<Trip>, ITripRepository
    {
        public TripRepository(ApplicationContext context) : base(context)
        {

        }

        public IQueryable<Passenger> GetPax()
        {
            return Db.Passengers;
        }
        public bool IsValidPassengerId(Guid passengerId)
        {
            return Db.Passengers.Any(_ => _.Id == passengerId);
        }
        public IQueryable<PaxListModel> GetPaxList()
        {
            return Db.Passengers.Select(j => new PaxListModel
            {
                Id = j.Id,
                Name = j.Name
            }).AsQueryable();
        }

    }
}
