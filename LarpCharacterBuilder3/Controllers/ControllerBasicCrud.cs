using HotChocolate;
using LarpCharacterBuilder3.Logic;
using Microsoft.AspNetCore.Mvc;

namespace LarpCharacterBuilder3
{
    public abstract class ControllerBasicCrud<TEntity> : ControllerBase, IControllerBasicCrud<TEntity>
    {
        private readonly IRepository<TEntity> _repository;
        public ControllerBasicCrud([Service] IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public ActionResult<TEntity> Index()
        {
            return Ok(_repository.GetAll());
        }

        public ActionResult<TEntity> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        public ActionResult<TEntity> GetById(long id)
        {
            return Ok(_repository.Get(id));
        }

        public ActionResult Delete(long id)
        {
            _repository.Delete(id);
            return Ok("Deleted Character with ID: " + id);
        }

        public ActionResult Update<TDto>(long id, TEntity entity, TDto dto)
        {
            _repository.Update<TDto>(id, entity, dto);
            return Ok("Updated Character ID: " + id);
        }
    }
}