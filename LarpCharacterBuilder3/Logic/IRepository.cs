using System.Collections.Generic;
using System.Linq;

namespace LarpCharacterBuilder3.Logic
{
    public interface IRepository<T>
    {
        public IQueryable<T> GetAll();
        public IQueryable<T> Get(long id);
        public void Delete(long id);
        public void Update(long id, T entity);
    }
}