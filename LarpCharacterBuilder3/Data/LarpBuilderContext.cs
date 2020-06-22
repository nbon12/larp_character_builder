using System;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterSkill>()
                .HasKey(sc => new {sc.CharacterId, sc.SkillId});
            modelBuilder.Entity<CharacterEvent>()
                .HasKey(sc => new {sc.CharacterId, sc.EventId});
        }
        public DbSet<Character> Character { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<CharacterEvent> CharacterEvents { get; set; }
        public DbSet<CharacterSkill> CharacterSkills { get; set; }
        
    }
}