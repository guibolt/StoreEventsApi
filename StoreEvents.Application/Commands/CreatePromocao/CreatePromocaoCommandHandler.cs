using MediatR;
using StoreEvents.Core.Command;
using StoreEvents.Core.Entitites;
using StoreEvents.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreEvents.Application.Commands.CreatePromocao
{
    public class CreatePromocaoCommandHandler : IRequestHandler<CreatePromocaoCommand, CommandReturn>
    {

        private IGenericRepository<Promocao> _genericRepository;

        public CreatePromocaoCommandHandler(IGenericRepository<Promocao> genericRepository) => _genericRepository = genericRepository;

        public async Task<CommandReturn> Handle(CreatePromocaoCommand request, CancellationToken cancellationToken)
        {
            var idProduto = Guid.Empty;
            var idCategoria = Guid.Empty;

            if (!request.EhValido())
                return new CommandReturn(false, request.Erros(), "");

            if (request.ProdutoId != null && !Guid.TryParse(request.ProdutoId, out idProduto))
                new CommandReturn(false, "Erro ao adicionar nova promoção");

            if (request.CategoriaId != null && !Guid.TryParse(request.CategoriaId, out  idCategoria))
                new CommandReturn(false, "Erro ao adicionar nova promoção");

            var promocao = new Promocao(request.Titulo, request.Descricao, 
                idCategoria, idProduto, request.TaxaDesconto, request.DataVencimento);

            var retornoAdicao = await _genericRepository.Adicionar(promocao);

            if (!retornoAdicao)
                return new CommandReturn(false, "Erro ao cadastar promoção");

            return retornoAdicao ? new CommandReturn(true, "Promoção adicionada com sucesso!") : new CommandReturn(false, "Erro ao adicionar nova promoção");
        }
    }
}
