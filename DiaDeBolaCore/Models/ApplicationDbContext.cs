using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiaDeBolaCore.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> WebsiteUsers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<EventStatus> EventStatus { get; set; }
        public DbSet<PlayerStatus> PlayerStatus { get; set; }
        public DbSet<EquipmentColor> EquipmentColors { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactList> ContactLists { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
