using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace TimeMachine.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Interaction> Interactions { get; set; }




        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}