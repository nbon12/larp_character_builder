using System;
using System.Collections.Generic;

namespace LarpCharacterBuilder3.Models
{
    public class Event : IEntity
    {
        public int Id { get; set; }
        public Character Character { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}