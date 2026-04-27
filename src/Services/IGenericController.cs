using System.Collections.Generic;

namespace PrimeSystems.Services
{
    public interface IGenericController<T, TId>
    {
        List<T> GetAll(bool includeInactive = false, int? pageNumber = null, int? pageSize = null);
        List<T> Search(string searchTerm, bool includeInactive = false, int? pageNumber = null, int? pageSize = null);
        T? GetById(TId id);
        bool Create(T item);
        bool Update(T item);
        bool Delete(TId id);
    }
}
