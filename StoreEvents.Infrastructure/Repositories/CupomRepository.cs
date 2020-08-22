using Microsoft.EntityFrameworkCore;
using StoreEvents.Core.Entitites;
using StoreEvents.Core.Repository;
using StoreEvents.Infrastructure.EntityContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreEvents.Infrastructure.Repositories
{
    public class CupomRepository : IGenericRepository<Cupom>
    {
        private readonly StoreEventsContext _storeEventsContext;

        public CupomRepository(StoreEventsContext storeEventsContext) => _storeEventsContext = storeEventsContext;
        

        public async Task<bool> Adicionar(Cupom item)
        {
            await _storeEventsContext.Cupons.AddAsync(item);

            var retornoAtualizacao = await _storeEventsContext.SaveChangesAsync();

            return retornoAtualizacao == 1;
        }

        public async Task<bool> Atualizar(Cupom item)
        {
            _storeEventsContext.Cupons.Update(item);

             var retornoAtualizacao = await _storeEventsContext.SaveChangesAsync();

            return retornoAtualizacao == 1;
        }

        public async Task<List<Cupom>> Buscar()
        {
            var listaCupons = await _storeEventsContext.Cupons.ToListAsync();

            return listaCupons;
        }

        public async Task<Cupom> BuscarPorId(Guid itemId)
        {
            var cupom = await _storeEventsContext.Cupons.FirstOrDefaultAsync(c => c.Id == itemId);

            return cupom ?? null;
        }

        public async Task<bool> Remover(Guid itemId)
        {

            var cupom = await _storeEventsContext.Cupons.FirstOrDefaultAsync(c => c.Id == itemId);

            if (cupom == null)
                return false;

            var retornoRemocao =  _storeEventsContext.Cupons.Remove(cupom);

            var retornoAtualizacao = await _storeEventsContext.SaveChangesAsync();

            return retornoAtualizacao == 1;
        }
    }
}
