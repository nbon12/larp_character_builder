using System.Collections.Generic;

namespace LarpCharacterBuilder3.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TotalCp { get; set; }
        public ICollection<CharacterSkill> CharacterSkills { get; set; }
        public ICollection<CharacterEvent> CharacterEvents { get; set; }
    }
}