using System.ComponentModel.DataAnnotations.Schema;

namespace LarpCharacterBuilder3.Models
{
    /// <summary>
    /// Represents a grant or gift of CP to a character.
    /// </summary>
    public class CpGrant : BaseEntity
    {
        [ForeignKey("Character")]
        public long CharacterId { get; set; }
        public Character Character { get; set; }
        public int Amount { get; set; } = 0;
        public string Reason { get; set; } = "";
    }
}