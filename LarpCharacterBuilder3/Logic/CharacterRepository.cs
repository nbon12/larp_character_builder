using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotChocolate;
using LarpCharacterBuilder3.Core.Core.Dapper;
using LarpCharacterBuilder3.Data;
using LarpCharacterBuilder3.Models;
using MySqlConnector.Logging;

namespace LarpCharacterBuilder3.Logic
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IDapperDataSession _dataSession;
        /*private readonly LarpBuilderContext _dbContext;
        private readonly IMapper _mapper;*/

        /*public CharacterRepository(
            [Service] LarpBuilderContext dbContext,
            [Service] IMapper mapper) : base(dbContext, mapper)
        {
        }*/
        public CharacterRepository(IDapperDataSession dataSession)
        {
            _dataSession = dataSession;
        }

        public async Task<int> CpRemaining(long characterId)
        {
            return 0;
        }

        public IQueryable<Character> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Character> Get(long id)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(long id, Character entity)
        {
            throw new NotImplementedException();
        }
    }
}
/**
private readonly IDapperDataSession _dataSession;

        public TitleRepository(IDapperDataSession dataSession) : base(dataSession, new SortDictionary() {{nameof(Title.title), SortDirection.Asc}})
        {
            _dataSession = dataSession;
        }
        
        public async Task<bool> IsTitleUnique(string title)
        {
            const string sql = @"
                SELECT COUNT(1) 
                FROM admin_title as T
                LEFT JOIN admin_title_alias as TA ON T.Id = TA.TitleId
                WHERE T.title = @Title OR TA.Alias = @Title;";

            return (await _dataSession.QueryAsync<int>(sql, new { Title = title })).FirstOrDefault() == 0;
        }
*/