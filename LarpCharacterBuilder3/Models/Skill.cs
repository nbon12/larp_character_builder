﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarpCharacterBuilder3.Models
{
    public class Skill : BaseEntity
    {
        public long? ParentSkillId { get; set; }
        public Skill ParentSkill;
        public string Name { get; set; }
        public int? Cost { get; set; }
        public string Description { get; set; }
        public ICollection<CharacterSkill> CharacterSkills;

        public override bool Equals(object obj)
        {
            var skill = obj as Skill;
            if (obj != null)
            {
                return skill.Name == Name;
            }
            return false;
        }
        
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        /// <summary>
        /// ReplacesParent indicates whether or not the parent skill should be replaced by this child skill.
        /// For example, if a person buys Maim, it should not replace the Warrior parent skill
        /// But if a character buys Maim 2, it should replace the Maim 1 skill. 
        /// </summary>
        public bool ReplacesParent { get; set; } = false;

        [NotMapped]
        public HashSet<Skill> Children { get; set; } = new HashSet<Skill>();
    }
}