using System;

namespace StoreEvents.Core.Entitites
{
    public class Cupom : BaseEntity
    {
        public string Codigo { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public double TaxaDesconto { get; private set; }
        public Guid? CategoriaId { get; private set; }
        public Guid? ProdutoId { get; private set; }

        public Cupom(string codigo, DateTime dataVencimento, double taxaDesconto, Guid? categoriaId, Guid? produtoId)
        {
            Codigo = codigo;
            DataVencimento = dataVencimento;
            TaxaDesconto = taxaDesconto;
            CategoriaId = categoriaId;
            ProdutoId = produtoId;
        }

        public void AplicaNovaDataVencimento(DateTime novaData) => DataVencimento = novaData;

        public void AtualizaDesconto(double novoDesconto) => TaxaDesconto = novoDesconto;
    }
}
