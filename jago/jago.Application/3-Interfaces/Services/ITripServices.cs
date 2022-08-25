using FluentValidation.Results;
using jago.Application.ViewModel;
using jago.domain.Entities;
using jago.domain.Model;

namespace jago.Application.Interfaces.Services
{
    public interface ITripServices : IDisposable
    {
        IEnumerable<TripViewModel> GetAll();
        TripViewModel GetById(Guid id);
        IEnumerable<TripViewModel> GetAllBy(Func<Trip, bool> exp);
        ValidationResult Add(TripViewModel vm);
        ValidationResult Update(TripViewModel vm);
        ValidationResult Remove(Guid id);
        IEnumerable<PassengerViewModel> GetPax();
        IEnumerable<PaxListModel> GetPaxList();
        IEnumerable<TripViewModel> GetOrder();
    }
}
