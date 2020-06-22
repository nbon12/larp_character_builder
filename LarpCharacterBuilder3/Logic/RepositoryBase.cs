using System;
using System.Linq;
using AutoMapper;
using HotChocolate;
using LarpCharacterBuilder3.Data;
using LarpCharacterBuilder3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LarpCharacterBuilder3.Logic
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        private readonly LarpBuilderContext _dbContext;
        private IMapper _mapper;
        protected RepositoryBase([Service] LarpBuilderContext dbContext, [Service] IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = _mapper;
        }
        public IQueryable<TEntity> getAll()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> get(long id)
        {
            return getAll().Where(entity => entity.Id == id);
        }

        public void delete(long id)
        {
            var entity = get(id).FirstOrDefault() ?? throw new Exception("ID not found, cannot delete.");
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }
        

        /**
         * Type DTO is the DTO to convert from.
         */
        public void Update<TDto>(long id, TEntity entity, TDto dto)
        {
            var untrackedEntity = get(id).AsNoTracking().FirstOrDefault();
            if (untrackedEntity == null) throw new Exception("Cannot update. ID not found: " + id);
            entity = validateUpdate(id, entity);
            var type = entity.GetType();
            //var dto = _mapper.Map<>(entity);
            var dtoOfCurrentState = _mapper.Map<TDto>(entity); // get a DTO representation of the current state of the model.
            dto.Patch(titleDto);
            var updatedDto = _titleService.Update(_mapper.Map<Title>(titleDto));

            
            _dbContext.Update(entity);
        }

        /**
         * Returns the validated Entity
         */
        public abstract TEntity validateUpdate(long id, TEntity entity);
    }
}