using AutoMapper;
using HotChocolate;
using LarpCharacterBuilder3.Logic;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace LarpCharacterBuilder3
{
    public abstract class ControllerBasicCrud<TEntity> : ControllerBase, IControllerBasicCrud<TEntity>
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        public ControllerBasicCrud([Service] IRepository<TEntity> repository, [Service] IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

        public ActionResult Update<TEntityy, TUpdateDto>(long id, Delta<TUpdateDto> deltaDto) where TUpdateDto : class
        {
            TEntityy deltaEntity = _mapper.Map<TEntityy>(deltaDto);
            _repository.Update(id, deltaEntity);
            return Ok("Updated Character ID: " + id);
        }
    }
}