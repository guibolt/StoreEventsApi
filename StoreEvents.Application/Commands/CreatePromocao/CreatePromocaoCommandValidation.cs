using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreEvents.Application.Commands.CreatePromocao
{
    public class CreatePromocaoCommandValidation : AbstractValidator<CreatePromocaoCommand>
    {
        public CreatePromocaoCommandValidation()
        {
            RuleFor(c => c.Titulo).
                NotNull().
                NotEmpty().
                WithMessage("Titulo inválido");
            
            RuleFor(c=> c.Descricao).
                NotNull().
                NotEmpty().
                WithMessage("Descricao inválida");

            RuleFor(c => c.TaxaDesconto).
                NotEqual(0).
                WithMessage("TaxaDesconto inválida");

            RuleFor(c => c.DataVencimento).
                NotEqual(new DateTime()).
                WithMessage("DataVencimento inválida");
        }
    }
}
