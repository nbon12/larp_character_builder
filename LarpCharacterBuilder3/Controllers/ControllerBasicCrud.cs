using System.Linq;
using AutoMapper;
using HotChocolate;
using LarpCharacterBuilder3.Logic;
using LarpCharacterBuilder3.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace LarpCharacterBuilder3
{
    public abstract class ControllerBasicCrud<TEntity> : ControllerBase, IControllerBasicCrud<TEntity> where TEntity : IEntity
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

        [HttpPost("{id:long}")]
        public ActionResult Update<TUpdateDto>(long id, [FromBody] Delta<TUpdateDto> deltaDto) where TUpdateDto : class
        {
            //TEntity deltaEntity = _mapper.Map<TEntity>(deltaDto);
            TEntity currentModel = _repository.Get(id).AsNoTracking().FirstOrDefault();
            TUpdateDto currentModelAsDto = _mapper.Map<TUpdateDto>(currentModel);
            deltaDto.Patch(currentModelAsDto);
            TEntity updatedCurrentModel = _mapper.Map<TEntity>(currentModelAsDto);
            _repository.Update(id, updatedCurrentModel);
            return Ok("Updated Character ID: " + id);
        }
    }
}