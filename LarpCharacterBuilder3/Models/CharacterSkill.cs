using System.ComponentModel.DataAnnotations.Schema;

namespace LarpCharacterBuilder3.Models
{
    public class CharacterSkill
    {
        [ForeignKey("Skill")]
        public long SkillId { get; set; } 
        public Skill Skill { get; set; }
        
        [ForeignKey("Character")]
        public long CharacterId { get; set; }
        public Character Character { get; set; }
    }
}