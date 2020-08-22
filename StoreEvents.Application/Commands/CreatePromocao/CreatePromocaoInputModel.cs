using System;
using System.Collections.Generic;
using System.Text;

namespace StoreEvents.Application.Commands.CreatePromocao
{
    public class CreatePromocaoInputModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string CategoriaId { get; set; }
        public string ProdutoId { get; set; }
        public double TaxaDesconto { get; set; }
        public DateTime DataVencimento { get; set; }
    }
   
}
