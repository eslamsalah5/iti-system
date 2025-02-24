using CRUDStudentsAndDepartments.Models;

namespace CRUDStudentsAndDepartments.Services
{
    public interface IEntity<T>
    {
        IEnumerable<T> GetAll();
        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(object id);

        void Save();
    }
}
