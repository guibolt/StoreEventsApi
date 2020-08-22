using System;
using System.Collections.Generic;
using System.Text;

namespace StoreEvents.Application.Commands.CreateCupom
{
    public class CreateCupomInputModel
    {
        public string Codigo { get;  set; }
        public double TaxaDesconto { get;  set; }
        public Guid? CategoriaId { get;  set; }
        public Guid? ProdutoId { get;  set; }
        public DateTime DataVencimento { get;  set; }
    }
}
