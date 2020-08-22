using FluentValidation.Results;
using MediatR;
using StoreEvents.Core.Query;
using StoreEvents.Core.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreEvents.Application.Queries.GetCupom
{
    public class GetCuponQuery : RequestBase, IRequest<QueryReturn>
    {
        public string CupomId { get; private set; }

        public GetCuponQuery(string cupomId) => CupomId = cupomId;

        public override bool EhValido()
        {
            Validation = new GetCupomQueryValidation().Validate(this);
            return Validation.IsValid;
        }

        public override IList<ValidationFailure> Erros() => Validation.Errors;
        
    }
}
