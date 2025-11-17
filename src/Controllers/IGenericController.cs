using System.Collections.Generic;

namespace PrimeSystems.Controllers
{
    public interface IGenericController<T, TId>
    {
        List<T> GetAll();
        T? GetById(TId id);
        bool Create(T item);
        bool Update(T item);
        bool Delete(TId id);
    }
}
