using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreEvents.Application.Commands.CreateCupom
{
    public class CreateCupomCommandValidation : AbstractValidator<CreateCupomCommand>
    {
        public CreateCupomCommandValidation()
        {
            RuleFor(c => c.Codigo)
                .NotEmpty()
                .NotNull()
                .WithMessage("O código inválido");

            RuleFor(c => c.TaxaDesconto)
                .NotEqual(0)
                .WithMessage("O código inválido");

            RuleFor(c => c.DataVencimento)
                .NotEmpty()
                .NotNull()
                .WithMessage("O código inválido");

        }
    }
}
