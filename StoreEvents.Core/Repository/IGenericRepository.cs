using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreEvents.Core.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task <bool>Adicionar(T item);
        Task<bool> Atualizar(T item);
        Task<bool> Remover(Guid itemId);
        Task<List<T>> Buscar();
        Task<T> BuscarPorId(Guid itemId);

    }
}
