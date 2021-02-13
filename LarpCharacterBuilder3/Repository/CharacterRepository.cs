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

        public int GetCpRemaining(long characterId)
        {
            return GetTotalCp(characterId) - GetCpSpent(characterId);
        }

        public int GetTotalCp(long characterId)
        {
            return Character.GlobalStartingCp + GetGamesAttendedCount(characterId) * 2
                + GetCharacterAdditionalCp(characterId);
        }

        private int GetCharacterAdditionalCp(long characterId)
        {
            //TODO: return SUM of additional CP grants.
            return 0;
        }

        public int GetGamesAttendedCount(long characterId)
        {
            return _dapperDataSession.Query<int>(
                @"
                SELECT COALESCE(count(*), 0) FROM CharacterEvents ce
                WHERE ce.CharacterId = @characterId
                ", new {characterId = characterId}
            ).FirstOrDefault();
        }

        public int GetCpSpent(long characterId)
        {
            return _dapperDataSession.Query<int>(
                @"
                SELECT COALESCE(sum(cost), 0)
                FROM CharacterSkills t
                JOIN Skill s on t.SkillId = s.Id
                WHERE t.CharacterId = @characterId
    
                ", new {characterId = characterId}
            ).FirstOrDefault();
        }
    }
}