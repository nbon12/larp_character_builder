using System;
using System.Linq;
using AutoMapper;
using HotChocolate;
using LarpCharacterBuilder3.Data;
using LarpCharacterBuilder3.Models;
using MySqlConnector.Logging;

namespace LarpCharacterBuilder3.Logic
{
    public class CharacterRepository : RepositoryBase<Character>, ICharacterRepository
    {
        /*private readonly LarpBuilderContext _dbContext;
        private readonly IMapper _mapper;*/

        public CharacterRepository([Service] LarpBuilderContext dbContext, [Service] IMapper mapper) : base(dbContext, mapper)
        {
            /*_dbContext = dbContext;
            _mapper = mapper;*/
        }

        public override Character validateUpdate(long id, Character entity)
        {
            Console.WriteLine("Validation passed.");
            return entity;
        }

        public void Update(long id, Character entity)
        {
            base.Update<CharacterDto>(id, entity);
        }
    }
}