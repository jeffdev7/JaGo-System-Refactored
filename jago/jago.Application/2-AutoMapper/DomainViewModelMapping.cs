using AutoMapper;
using jago.Application.ViewModel;
using jago.domain.Entities;

namespace jago.Application.AutoMapper
{
    public class DomainViewModelMapping : Profile
    {
        public DomainViewModelMapping()
        {
            CreateMap<Passenger, PassengerViewModel>();
            CreateMap<Trip, TripViewModel>();
        }
    }
}
