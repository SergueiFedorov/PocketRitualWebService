using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PocketRitualBussinessLogic.Services;

namespace PocketRitual.Models
{
    public interface IPocketRitualDbContext : IDisposable
    {
        DbSet<Action> Actions { get; set; }
        DbSet<ActionCategory> ActionCategories { get; set; }
        DbSet<Card> Cards { get; set; }
        DbSet<CardAction> CardActions { get; set; }
        DbSet<CardCategory> CardCategories { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<Journey> Journeys { get; set; }
        DbSet<JourneyCard> JourneyCards { get; set; }
        DbSet<User> Users { get; set; }

        ActionService ActionService { get; set; }
        ActionCategoryService ActionCategoryService { get; set; }
        CardService CardService { get; set; }
        CardActionService CardActionService { get; set; }
        CardCategoryService CardCategoryService { get; set; }
        EventService EventService { get; set; }
        JourneyService JourneyService { get; set; }
        JourneyCardService JourneyCardService { get; set; }
        UserService UserService { get; set; }

        int SaveChanges();
    }
}