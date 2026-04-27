using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeSystems.Services
{
    public interface IGenericController<T, TId>
    {
        Task<List<T>> GetAllAsync(bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default);
        Task<List<T>> SearchAsync(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null, CancellationToken ct = default);
        Task<T?> GetByIdAsync(TId id, CancellationToken ct = default);
        Task<bool> CreateAsync(T item, CancellationToken ct = default);
        Task<bool> UpdateAsync(T item, CancellationToken ct = default);
        Task<bool> DeleteAsync(TId id, CancellationToken ct = default);

        List<T> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null);
        List<T> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null);
        T? GetById(TId id);
        bool Create(T item);
        bool Update(T item);
        bool Delete(TId id);
    }
}