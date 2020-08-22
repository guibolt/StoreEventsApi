using System;
using System.Collections.Generic;
using System.Text;

namespace StoreEvents.Core.Entitites
{
    public class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime DataCadastro { get; private set; } = DateTime.Now;
    }
}
