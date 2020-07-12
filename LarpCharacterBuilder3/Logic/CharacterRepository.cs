using System;
using System.Linq;
using System.Threading.Tasks;
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

        public CharacterRepository(
            [Service] LarpBuilderContext dbContext,
            [Service] IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override Character validateUpdate(long id, Character entity)
        {
            Console.WriteLine("Validation Not performed.");
            return entity;
        }

        public async Task<int> GetCpRemaining(long characterId)
        {
            return 0;
        }
    }
}