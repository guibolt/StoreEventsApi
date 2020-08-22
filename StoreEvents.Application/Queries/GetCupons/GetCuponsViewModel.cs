using StoreEvents.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreEvents.Application.Queries.GetCupons
{
    public class GetCuponsViewModel
    {
        public List<Cupom> Cupons { get; private set; }

        public GetCuponsViewModel(List<Cupom> cupons) => Cupons = cupons;
        
    }
}
