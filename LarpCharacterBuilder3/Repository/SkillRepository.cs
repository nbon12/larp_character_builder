using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotChocolate;
using LarpCharacterBuilder3.Core.Dapper;
using LarpCharacterBuilder3.Data;
using LarpCharacterBuilder3.Models;

namespace LarpCharacterBuilder3.Logic
{
    public interface ISkillRepository : IRepository<Skill>
    {
        public HashSet<Skill> GetSkillTree();
        public HashSet<Skill> GetPrimarySkills();
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

        public HashSet<Skill> GetSkillTree()
        {
            var skills = _dbContextEf.Skill.ToHashSet();
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

        public HashSet<Skill> GetPrimarySkills()
        {
            var skills = GetSkillTree();
            var primarySkills = new HashSet<Skill>();
            foreach (Skill skill in skills)
            {
                if (skill.ParentSkillId == null)
                {
                    primarySkills.Add(skill);
                }
            }
            return primarySkills;
        }

        public override Skill validateUpdate(long id, Skill entity)
        {
            throw new System.NotImplementedException();
        }
    }
}