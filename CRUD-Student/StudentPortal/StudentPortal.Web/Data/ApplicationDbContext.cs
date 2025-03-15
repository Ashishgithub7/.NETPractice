using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Data
{
    public class ApplicationDbContext : DbContext
    //Bridge between the database and the application
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) /* tells which db to connect to  */
        {
            
        }
        public DbSet<Student> Students { get; set; }

    }
}
