using System;

namespace StoreEvents.Core.Entitites
{
    public class Promocao : BaseEntity
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public Guid? CategoriaId { get; private set; }
        public Guid? ProdutoId { get; private set; }
        public double TaxaDesconto { get; private set; }
        public DateTime DataVencimento { get; private set; }

        public Promocao(string titulo, string descricao, Guid? categoriaId, Guid? produtoId, double taxaDesconto, DateTime dataVencimento)
        {
            Titulo = titulo;
            Descricao = descricao;
            CategoriaId = categoriaId;
            ProdutoId = produtoId;
            TaxaDesconto = taxaDesconto;
            DataVencimento = dataVencimento;
        }

        public void AtualizaTitulo(string novoTitulo) => Titulo = novoTitulo;

        public void AtualizaDescricao(string novaDescricao) => Descricao = novaDescricao;

        public void AplicaNovaDataVencimento(DateTime novaData) => DataVencimento = novaData;

        public void AtualizaDesconto(double novoDesconto) => TaxaDesconto = novoDesconto; 
    }
}
