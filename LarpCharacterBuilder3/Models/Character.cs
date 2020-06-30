using System.Collections.Generic;

namespace LarpCharacterBuilder3.Models
{
    public class Character : BaseEntity
    {
        private static readonly int GlobalStartingCp = 15;
        public string Name { get; set; }
        public int StartingCp { get; set; } = GlobalStartingCp;
        public ICollection<CharacterSkill> CharacterSkills { get; set; }
        public ICollection<CharacterEvent> CharacterEvents { get; set; }
    }
}