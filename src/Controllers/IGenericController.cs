using System.Collections.Generic;

namespace PrimeSystems.Controllers
{
    public interface IGenericController<T>
    {
        List<T> GetAll();
        T? GetById(object id);
        bool Create(T item);
        bool Update(T item);
        bool Delete(object id);
    }
}
