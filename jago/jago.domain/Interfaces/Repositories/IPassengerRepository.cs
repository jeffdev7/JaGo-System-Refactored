using jago.domain.Entities;

namespace jago.domain.Interfaces.Repositories
{
    public interface IPassengerRepository : IRepository<Passenger>
    {
        IQueryable<Passenger> GetPax();
    }
}
