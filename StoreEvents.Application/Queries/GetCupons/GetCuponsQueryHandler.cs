using MediatR;
using StoreEvents.Core.Entitites;
using StoreEvents.Core.Query;
using StoreEvents.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreEvents.Application.Queries.GetCupons
{
    public class GetCuponsQueryHandler : IRequestHandler<GetCuponsQuery, QueryReturn>
    {
        private readonly IGenericRepository<Cupom> _genericRepository;

        public GetCuponsQueryHandler(IGenericRepository<Cupom> genericRepository) => _genericRepository = genericRepository;
        
        public async Task<QueryReturn> Handle(GetCuponsQuery request, CancellationToken cancellationToken)
        {
            var listaCupons = await _genericRepository.Buscar();

            return listaCupons != null ? new QueryReturn(true, "Consulta realizada com sucesso", listaCupons) : new QueryReturn(false, "Erro ao consultar");
        }
    }
}
