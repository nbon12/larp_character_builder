using System.Collections.Generic;
using System.Linq;
using LarpCharacterBuilder3.Data;
using Microsoft.EntityFrameworkCore;

namespace LarpCharacterBuilder3.Models
{
    public class Character : BaseEntity
    {
        public static readonly int GlobalStartingCp = 15;
        public string Name { get; set; }
        public int StartingCp { get; set; } = GlobalStartingCp;
        public ICollection<CharacterSkill> CharacterSkills { get; set; }
        public ICollection<CharacterEvent> CharacterEvents { get; set; }
    }
}