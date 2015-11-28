namespace TodoApp.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<ToDo> ToDos { get; set; } // marking as virtual allows mocking override

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}