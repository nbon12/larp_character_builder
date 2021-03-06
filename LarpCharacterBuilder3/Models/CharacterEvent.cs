﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LarpCharacterBuilder3.Models
{
    public class CharacterEvent
    {
        [ForeignKey("Event")]
        public long EventId { get; set; }
        
        public Event Event { get; set; }
        
        [ForeignKey("Character")]
        public long CharacterId { get; set; }
        
        public Character Character { get; set; }
    }
}