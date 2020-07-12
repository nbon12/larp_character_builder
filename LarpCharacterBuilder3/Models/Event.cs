using System;
using System.Collections.Generic;

namespace LarpCharacterBuilder3.Models
{
    /// <summary>
    /// Represents an instance of a Larp game on a date.
    /// </summary>
    public class Event : BaseEntity
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Title { get; set; }
        public string PublicDescription { get; set; }
        public string PlotNotes { get; set; }
        public bool Cancelled { get; set; } = false;
    }
}