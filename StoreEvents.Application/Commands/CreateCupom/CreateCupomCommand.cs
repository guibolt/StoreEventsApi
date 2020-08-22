using FluentValidation.Results;
using MediatR;
using StoreEvents.Core.Command;
using StoreEvents.Core.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreEvents.Application.Commands.CreateCupom
{
    public class CreateCupomCommand : RequestBase ,IRequest<CommandReturn>
    {
        public string Codigo { get; private set; }
        public double TaxaDesconto { get; private set; }
        public Guid? CategoriaId { get; private set; }
        public Guid? ProdutoId { get; private set; }
        public DateTime DataVencimento { get; private set; }

        public CreateCupomCommand(CreateCupomInputModel createCupomInput)
        {
            Codigo = createCupomInput.Codigo;
            TaxaDesconto = createCupomInput.TaxaDesconto;
            CategoriaId = createCupomInput.CategoriaId;
            ProdutoId = createCupomInput.ProdutoId;
            DataVencimento = createCupomInput.DataVencimento;
        }

        public override bool EhValido()
        {
            Validation = new CreateCupomCommandValidation().Validate(this);
            return Validation.IsValid;
        }

        public override IList<ValidationFailure> Erros() => Validation.Errors;
    
    }
}
