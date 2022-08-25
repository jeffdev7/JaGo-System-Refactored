using AutoMapper;
using jago.Application.ViewModel;
using jago.domain.Entities;

namespace jago.Application.AutoMapper
{
    public class ViewModelDomainMapping : Profile
    {
        public ViewModelDomainMapping()
        {
            CreateMap<PassengerViewModel, Passenger>();
            CreateMap<TripViewModel, Trip>();
        }
    }
}
//numerate folder 1-vm 2 automapper etc