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
        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> Get(long id)
        {
            return GetAll().Where(entity => entity.Id == id);
        }

        public void Delete(long id)
        {
            var entity = Get(id).FirstOrDefault() ?? throw new Exception("ID not found, cannot delete.");
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }
        

        /**
         * Type DTO is the DTO to convert from.
         */
        public void Update(long id, TEntity entity)
        {
            var untrackedEntity = Get(id).AsNoTracking().FirstOrDefault();
            if (untrackedEntity == null) throw new Exception("Cannot update. ID not found: " + id);
            untrackedEntity = validateUpdate(id, untrackedEntity);
            _dbContext.Update(untrackedEntity);
        }
        

        /**
         * Returns the validated Entity
         */
        public abstract TEntity validateUpdate(long id, TEntity entity);
    }
}