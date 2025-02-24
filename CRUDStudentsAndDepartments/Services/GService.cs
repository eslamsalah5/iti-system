using CRUDStudentsAndDepartments.Data;

namespace CRUDStudentsAndDepartments.Services
{
    public class GService<T>:IEntity<T> where T : class
    {
        MvcDbContext context;
        public GService(MvcDbContext _context) 
        {
            context = _context;
        }

        public void Add(T entity)
        {
            context.Add(entity);
        }

        public void Delete(object id)
        {
            T entity = context.Set<T>().Find(id);
            if (entity != null)
            {
                context.Remove(entity);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(object id)
        {
           return context.Set<T>().Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
             context.Update(entity);
        }
    }
}
