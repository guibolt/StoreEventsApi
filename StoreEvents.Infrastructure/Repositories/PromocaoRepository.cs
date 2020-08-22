using Microsoft.EntityFrameworkCore;
using StoreEvents.Core.Entitites;
using StoreEvents.Core.Repository;
using StoreEvents.Infrastructure.EntityContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreEvents.Infrastructure.Repositories
{
    public class PromocaoRepository : IGenericRepository<Promocao>
    {

        private readonly StoreEventsContext _storeEventsContext;

        public PromocaoRepository(StoreEventsContext storeEventsContext) => _storeEventsContext = storeEventsContext;

        public async Task<bool> Adicionar(Promocao item)
        {
            await _storeEventsContext.Promocoes.AddAsync(item);

            var retornoAtualizacao = await _storeEventsContext.SaveChangesAsync();

            return retornoAtualizacao == 1;
        }

        public async Task<bool> Atualizar(Promocao item)
        {
            _storeEventsContext.Promocoes.Update(item);

            var retornoAtualizacao = await _storeEventsContext.SaveChangesAsync();

            return retornoAtualizacao == 1;
        }

        public async Task<List<Promocao>> Buscar()
        {
            var listaPromocoes = await _storeEventsContext.Promocoes.ToListAsync();

            return listaPromocoes;
        }

        public Task<Promocao> BuscarPorId(Guid itemId) =>
        
            throw new NotImplementedException();
        

        public async Task<bool> Remover(Guid itemId)
        {

            var cupom = await _storeEventsContext.Cupons.FirstOrDefaultAsync(c => c.Id == itemId);

            if (cupom == null)
                return false;

            var retornoRemocao = _storeEventsContext.Cupons.Remove(cupom);

            var retornoAtualizacao = await _storeEventsContext.SaveChangesAsync();

            return retornoAtualizacao == 1;
        }
    }
}

