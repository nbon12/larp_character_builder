using System;
using System.Collections.Generic;

namespace LarpCharacterBuilder3.Models
{
    public class Event : BaseEntity
    {
        public Character Character { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}