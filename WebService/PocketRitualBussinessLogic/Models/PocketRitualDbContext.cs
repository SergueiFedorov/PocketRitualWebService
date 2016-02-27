namespace PocketRitual.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public partial class PocketRitualDbContext : DbContext, IPocketRitualDbContext
    {
        public PocketRitualDbContext()
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
        
        //Dispose model

        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<ActionCategory> ActionCategories { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<CardAction> CardActions { get; set; }
        public virtual DbSet<CardCategory> CardCategories { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Journey> Journeys { get; set; }
        public virtual DbSet<JourneyCard> JourneyCards { get; set; }
        public virtual DbSet<User> Users { get; set; }
        
    }
}
