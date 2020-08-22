using FluentValidation;
using StoreEvents.Application.Queries.GetCupons;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreEvents.Application.Queries.GetCupom
{
   public class GetCupomQueryValidation : AbstractValidator<GetCuponQuery>
    {
        public GetCupomQueryValidation()
        {
            RuleFor(c => c.CupomId)
                .NotEmpty()
                .NotNull()
                .WithMessage("CupomId inválido!");
        }

    }
}
