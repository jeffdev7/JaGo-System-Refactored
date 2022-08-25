using FluentValidation;
using jago.domain.Entities;

namespace jago.domain.Validator
{
    public class TripAddValidator : AbstractValidator<Trip>
    {
        public TripAddValidator()
        {
            RuleFor(j => j.PassengerId).NotNull();
            RuleFor(j => j.PassengerId).NotEmpty().WithMessage("Pax Id is empty.");
            RuleFor(j => j.Origem).NotEmpty().WithMessage("Campo obrigatório.");
            RuleFor(j => j.Origem).NotNull();
            RuleFor(j => j.Destino).NotEmpty().WithMessage("Campo obrigatório.");
            RuleFor(j => j.Destino).NotNull();
            RuleFor(j => j.Departure).NotEmpty().WithMessage("Campo obrigatório.");
            RuleFor(j => j.Departure).NotNull();
            RuleFor(j => j.Arrival).NotEmpty().WithMessage("Campo obrigatório.");
            RuleFor(j => j.Arrival).NotNull();
        }
    }

        public class TripUpdateValidator : AbstractValidator<Trip>
        {
            public TripUpdateValidator()
            {
                RuleFor(j => j.Id).NotEmpty().WithMessage("Id");
                RuleFor(j => j.PassengerId).NotEmpty().WithMessage("Campo obrigatório.");
                RuleFor(j => j.Origem).NotEmpty().WithMessage("Campo obrigatório.");
                RuleFor(j => j.Destino).NotEmpty().WithMessage("Campo obrigatório.");
                RuleFor(j => j.Departure).NotEmpty().WithMessage("Campo obrigatório.");
                RuleFor(j => j.PassengerId).NotEmpty().WithMessage("Campo obrigatório.");
                RuleFor(j => j.Destino).NotEmpty().WithMessage("Campo obrigatório.");
                RuleFor(j => j.Departure).NotEmpty().WithMessage("Campo obrigatório.");
                
            }
        }

        public class TripRemoveValidator : AbstractValidator<Trip>
        {
            public TripRemoveValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
            }
        }
    
}
