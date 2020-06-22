using System.Collections.Generic;

namespace LarpCharacterBuilder3.Models
{
    public class CharacterEvent : IEntity
    {
        public long EventId { get; set; }
        public Event Event { get; set; }
        public long CharacterId { get; set; }
        public Character Character { get; set; }
        
    }
}