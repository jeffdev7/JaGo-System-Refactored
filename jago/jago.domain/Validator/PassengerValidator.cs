using FluentValidation;
using jago.domain.Entities;

namespace jago.domain.Validator
{
    public class PassengerValidator : AbstractValidator<Passenger>
    {
        public PassengerValidator()
        {
            RuleFor(j => j.Name).NotEmpty().WithMessage("Campo obrigatório");
            RuleFor(j => j.Name).NotNull();
            RuleFor(j => j.CPF).NotEmpty().WithMessage("Campo obrigatório");
            RuleFor(j => j.Celular).NotEmpty().WithMessage("Campo obrigatório");
            RuleFor(j => j.Celular).NotNull();
            RuleFor(j => j.Email).NotEmpty().WithMessage("Campo obrigatório");
            RuleFor(j => j.Email).NotNull();
        }

        public class PassengerUpdateValidator : AbstractValidator<Passenger>
        {
            public PassengerUpdateValidator()
            {
                RuleFor(j => j.Name).NotEmpty().WithMessage("Campo obrigatório");
                RuleFor(j => j.Name).NotNull();
                RuleFor(j => j.CPF).NotEmpty().WithMessage("Campo obrigatório");
                RuleFor(j => j.Celular).NotEmpty().WithMessage("Campo obrigatório");
                RuleFor(j => j.Celular).NotNull();
                RuleFor(j => j.Email).NotEmpty().WithMessage("Campo obrigatório");
                RuleFor(j => j.Email).NotNull();
            }
        }

        public class PassengerRemoveValidator : AbstractValidator<Passenger>
        {
            public PassengerRemoveValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
            }
        }

    }
}
