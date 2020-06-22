using System.ComponentModel.DataAnnotations;

namespace LarpCharacterBuilder3.Models
{
    public class CharacterSkill : IEntity
    {
        
        public long CharacterId { get; set; }
        
        public long SkillId { get; set; }
        public Skill Skill { get; set; }
        public Character Character { get; set; }
    }
}