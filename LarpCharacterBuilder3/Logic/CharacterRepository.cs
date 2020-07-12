using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotChocolate;
using LarpCharacterBuilder3.Core.Dapper;
using LarpCharacterBuilder3.Data;
using LarpCharacterBuilder3.Models;
using MySqlConnector.Logging;

namespace LarpCharacterBuilder3.Logic
{
    public class CharacterRepository : RepositoryBase<Character>, ICharacterRepository
    {
        private readonly IDapperDataSession _dapperDataSession;
        /*private readonly LarpBuilderContext _dbContext;
        private readonly IMapper _mapper;*/

        public CharacterRepository(
            [Service] LarpBuilderContext dbContext,
            [Service] IMapper mapper,
            [Service] IDapperDataSession dapperDataSession) : base(dbContext, mapper)
        {
            _dapperDataSession = dapperDataSession;
        }

        public override Character validateUpdate(long id, Character entity)
        {
            Console.WriteLine("Validation Not performed.");
            return entity;
        }

        public async Task<int> GetCpRemaining(long characterId)
        {
            return _dapperDataSession.Query<int>("SELECT 1 FROM dual").FirstOrDefault();
        }
    }
}