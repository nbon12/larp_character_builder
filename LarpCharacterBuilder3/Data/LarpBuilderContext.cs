using LarpCharacterBuilder3.Models;
using Microsoft.EntityFrameworkCore;

namespace LarpCharacterBuilder3.Data
{
    public class LarpBuilderContext : DbContext
    {
        public LarpBuilderContext (DbContextOptions<LarpBuilderContext> options)
            : base(options)
        {
            
        }
        public DbSet<Character> Character { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<Event> Event { get; set; }
    }
}