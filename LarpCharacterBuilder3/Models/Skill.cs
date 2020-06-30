using System.Collections.Generic;

namespace LarpCharacterBuilder3.Models
{
    public class Skill : BaseEntity
    {
        public Skill ParentSkill;
        private ICollection<Skill> _children;
        public string Name { get; set; }
        public int? Cost { get; set; }
        public string Description { get; set; }
        public ICollection<CharacterSkill> CharacterSkills;

        public ICollection<Skill> Children
        {
            get => _children;
            set => _children = value;
        }
    }
}