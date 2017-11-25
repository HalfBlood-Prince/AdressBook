using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GCon.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<AddressGroup> AddressGroups { get; set; }
        public DbSet<AddressGroupType> AddressGroupTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}