using System.Collections.Generic;

namespace LarpCharacterBuilder3.Models
{
    public class Character
    {
        public string Name { get; set; }
        public int? TotalCp { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public List<object> Events { get; set; }
    }
}