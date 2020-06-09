using System;
using System.Collections.Generic;

namespace LarpCharacterBuilder3.Models
{
    public class Event
    {
        public ICollection<Character> Characters { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}