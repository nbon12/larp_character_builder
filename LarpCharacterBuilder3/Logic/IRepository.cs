using System.Collections.Generic;
using System.Linq;
using LarpCharacterBuilder3.Models;

namespace LarpCharacterBuilder3.Logic
{
    public interface IRepository<T> where T : IEntity
    {
        public IQueryable<T> GetAll();
        public IQueryable<T> Get(long id);
        public void Delete(long id);
        public void Update(long id, T entity);
    }
}