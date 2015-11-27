namespace TodoApp.Models
{
    using System.Data.Entity;

    public class ApplicationDbContextInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
    }
}