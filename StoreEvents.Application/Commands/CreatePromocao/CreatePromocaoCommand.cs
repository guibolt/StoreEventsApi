using FluentValidation.Results;
using MediatR;
using StoreEvents.Core.Command;
using StoreEvents.Core.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreEvents.Application.Commands.CreatePromocao
{
    public class CreatePromocaoCommand : RequestBase, IRequest<CommandReturn>
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string CategoriaId { get; private set; }
        public string ProdutoId { get; private set; }
        public double TaxaDesconto { get; private  set; }
        public DateTime DataVencimento { get; private set; }

        public CreatePromocaoCommand(CreatePromocaoInputModel inputModel)
        {
            Titulo = inputModel.Titulo;
            Descricao = inputModel.Descricao;
            CategoriaId = inputModel.CategoriaId;
            ProdutoId = inputModel.ProdutoId;
            TaxaDesconto = inputModel.TaxaDesconto;
            DataVencimento = inputModel.DataVencimento;
        }

        public override bool EhValido()
        {
            Validation = new CreatePromocaoCommandValidation().Validate(this);
            return Validation.IsValid;
        }
        public override IList<ValidationFailure> Erros() => Validation.Errors;
    }
}
