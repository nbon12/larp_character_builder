using System.ComponentModel.DataAnnotations;

namespace LarpCharacterBuilder3.Models
{
    
    public class BaseEntity : IEntity
    {
        [Key]
        public long Id { get; set; }
    }
}