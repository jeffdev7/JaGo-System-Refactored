using jago.domain.Entities;
using jago.domain.Model;

namespace jago.domain.Interfaces.Repositories
{
    public interface ITripRepository : IRepository<Trip>
    {
        IQueryable<Passenger> GetPax();
        bool IsValidPassengerId(Guid passengerId);
        IQueryable<PaxListModel> GetPaxList();
    }
}
