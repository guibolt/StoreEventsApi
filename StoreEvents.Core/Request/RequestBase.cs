using FluentValidation.Results;
using System.Collections.Generic;

namespace StoreEvents.Core.Request
{
    public abstract class RequestBase
    {
        protected ValidationResult Validation { get; set; }
        public abstract bool EhValido();
        public abstract IList<ValidationFailure> Erros();
    }
}
