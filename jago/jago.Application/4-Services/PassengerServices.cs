using AutoMapper;
using FluentValidation.Results;
using jago.Application.Interfaces.Services;
using jago.Application.ViewModel;
using jago.domain.Entities;
using jago.domain.Interfaces.Repositories;
using jago.domain.Validator;
using static jago.domain.Validator.PassengerValidator;

namespace jago.Application.Services
{
    public class PassengerServices : IPassengerServices
    {
        private readonly IMapper _mapper;
        private readonly IPassengerRepository _paxRepository;

        public PassengerServices(IMapper mapper, IPassengerRepository passengerRepository)
        {
            _mapper = mapper;
            _paxRepository = passengerRepository;
        }
        public IEnumerable<PassengerViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<PassengerViewModel>>(_paxRepository.GetAll());
        }
        public PassengerViewModel GetById(Guid id)
        {
            return _mapper.Map<PassengerViewModel>(_paxRepository.GetById(id));
        }
        public IEnumerable<PassengerViewModel> GetAllBy(Func<Passenger, bool> exp)
        {
            return _mapper.Map<IEnumerable<PassengerViewModel>>(_paxRepository.GetAllBy(exp));
        }
        public ValidationResult Add(PassengerViewModel vm)
        {
            var entity = _mapper.Map<Passenger>(vm);
            var validationResult = new PassengerValidator().Validate(entity);
            if (validationResult.IsValid)
                _paxRepository.Add(entity);

            return validationResult;

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public IEnumerable<PassengerViewModel> GetPax()
        {
            return _mapper.Map<IEnumerable<PassengerViewModel>>(_paxRepository.GetPax());
        }

        public ValidationResult Remove(Guid id)
        {
            var entity = _paxRepository.GetById(id);
            var validationResult = new PassengerRemoveValidator().Validate(entity);

            if (validationResult.IsValid)
                _paxRepository.Remove(id);

            return validationResult;
        }

        public ValidationResult Update(PassengerViewModel vm)
        {
            var entity = _mapper.Map<Passenger>(vm);
            var validationResult = new PassengerUpdateValidator().Validate(entity);

            if (validationResult.IsValid)
            {
                _paxRepository.Update(entity);
            }

            return validationResult;
        }
    }
}
