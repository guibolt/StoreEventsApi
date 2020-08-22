using MediatR;
using StoreEvents.Core.Command;
using StoreEvents.Core.Entitites;
using StoreEvents.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreEvents.Application.Commands.CreateCupom
{
    public class CreateCupomCommandHandler : IRequestHandler<CreateCupomCommand, CommandReturn>
    {
        private readonly IGenericRepository<Cupom> _genericRepository;

        public CreateCupomCommandHandler(IGenericRepository<Cupom> genericRepository) =>  _genericRepository = genericRepository;
        
        public async Task<CommandReturn> Handle(CreateCupomCommand request, CancellationToken cancellationToken)
        {

            if (!request.EhValido())
                return new CommandReturn(false,request.Erros(),"");

            var cupom = new Cupom(request.Codigo, request.DataVencimento,
                request.TaxaDesconto, request.CategoriaId, request.ProdutoId);

           var retornoAdicao =  await _genericRepository.Adicionar(cupom);

            if (!retornoAdicao)
                return new CommandReturn(false, "Erro ao cadastar cupom");

            return retornoAdicao ? new CommandReturn(true, "Cupom adicionado com sucesso!") : new CommandReturn(false, "Erro ao adicionar novo cupom");
           
        }
    }
}
