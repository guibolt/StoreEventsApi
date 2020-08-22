using MediatR;
using StoreEvents.Core.Entitites;
using StoreEvents.Core.Query;
using StoreEvents.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreEvents.Application.Queries.GetCupom
{
    public class GetCupomHandler : IRequestHandler<GetCuponQuery, QueryReturn>
    {

        private readonly IGenericRepository<Cupom> _genericRepository;

        public GetCupomHandler(IGenericRepository<Cupom> genericRepository) => _genericRepository = genericRepository;

        public async Task<QueryReturn> Handle(GetCuponQuery request, CancellationToken cancellationToken)
        {
            if (!request.EhValido())
                return new QueryReturn(false, request.Erros(), "");


            if (!Guid.TryParse(request.CupomId, out Guid idCupom))
                return null;

            var cumpom = await _genericRepository.BuscarPorId(idCupom);

            return cumpom != null ? new QueryReturn(true, "Consulta realizada com sucesso", cumpom) : new QueryReturn(false, "Erro ao consultar");
           
        }
    }
}
