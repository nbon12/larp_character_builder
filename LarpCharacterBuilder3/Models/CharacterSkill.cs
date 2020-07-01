using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarpCharacterBuilder3.Models
{
    public class CharacterSkill
    {
        [ForeignKey("Character")]
        public long CharacterId { get; set; }
        
        [ForeignKey("Skill")]
        public long SkillId { get; set; }
        public Skill Skill { get; set; }
        public Character Character { get; set; }
    }
}