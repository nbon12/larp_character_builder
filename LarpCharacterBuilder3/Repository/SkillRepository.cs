using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HotChocolate;
using LarpCharacterBuilder3.Core.Dapper;
using LarpCharacterBuilder3.Data;
using LarpCharacterBuilder3.Models;

namespace LarpCharacterBuilder3.Logic
{
    public interface ISkillRepository
    {
        public IEnumerable<Skill> GetSkillTree();
        public IEnumerable<Skill> GetPrimarySkills();
    }
    public class SkillRepository : RepositoryBase<Skill>, ISkillRepository
    {
        private readonly LarpBuilderContext _dbContextEf;
        private readonly IMapper _mapper;
        private readonly IDapperDataSession _dapperDataSessionLarpBuilderContext;

        public SkillRepository( 
            [Service] LarpBuilderContext dbContextEF,
            [Service] IMapper mapper,
            [Service] IDapperDataSession dapperDataSessionLarpBuilderContext
            ) : base(dbContextEF, mapper)
        {
            _dbContextEf = dbContextEF;
            _mapper = mapper;
            _dapperDataSessionLarpBuilderContext = dapperDataSessionLarpBuilderContext;
        }

        public IEnumerable<Skill> GetSkillTree()
        {
            var skills = _dbContextEf.Skill.ToList();
            foreach(Skill skill in skills)
            {
                foreach (Skill childskill in skills)
                {
                    if (childskill.ParentSkillId == skill.Id)
                    {
                        skill.Children.Add(childskill);
                    }
                }
            }
            return skills;
        }
        
        
        public override Skill validateUpdate(long id, Skill entity)
        {
            throw new System.NotImplementedException();
        }
    }
}