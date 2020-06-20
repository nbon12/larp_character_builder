using System.Collections.Generic;

namespace LarpCharacterBuilder3.Models
{
    public class CharacterEvent
    {
        public int Id { get; set; }
        public Event Event { get; set; }

        public Character Characters { get; set; }
        
    }
}