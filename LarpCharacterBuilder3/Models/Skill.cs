using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        /// <summary>
        /// Whether or not the parent skill should be replaced by this child skill.
        /// For example, if a person buys Maim, it should not replace the Warrior parent skill
        /// But if a character buys Maim 2, it should replace the Maim 1 skill. 
        /// </summary>
        public bool ReplacesParent { get; set; } = false;

        public ICollection<Skill> Children
        {
            get => _children;
            set => _children = value;
        }
    }
}