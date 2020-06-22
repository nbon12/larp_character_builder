using Microsoft.AspNetCore.Mvc;

namespace LarpCharacterBuilder3
{
    /**
     * Inherit this Base controller to add basic CRUD operations.
     */
    public interface IControllerBasicCrud<TEntity>
    {
        public ActionResult<TEntity> Index();
        public ActionResult<TEntity> GetAll();
        public ActionResult<TEntity> GetById(long id);
    }
}