using FluentValidation.Results;
using jago.Application.ViewModel;
using jago.domain.Entities;

namespace jago.Application.Interfaces.Services
{
    public interface IPassengerServices : IDisposable
    {
        IEnumerable<PassengerViewModel> GetAll();
        PassengerViewModel GetById(Guid id);
        IEnumerable<PassengerViewModel> GetAllBy(Func<Passenger, bool> exp);
        ValidationResult Add(PassengerViewModel vm);
        ValidationResult Update(PassengerViewModel vm);
        ValidationResult Remove(Guid id);
        IEnumerable<PassengerViewModel> GetPax();

    }
}
