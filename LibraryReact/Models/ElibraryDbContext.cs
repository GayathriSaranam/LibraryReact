using Microsoft.EntityFrameworkCore;
namespace LibraryReact.Models
{
    public class ElibraryDbContext : DbContext
    {
        public DbSet<Admins> admins  { get; set; }
        public DbSet<Publishers> publishers { get; set; }

        public DbSet<Authors> authors { get; set; }

        public DbSet<Members> members { get; set; }

        public DbSet<Books> books { get; set; }

        public DbSet<IssueBooks> issueBooks { get; set; }



        public ElibraryDbContext(DbContextOptions<ElibraryDbContext> options) : base(options)
        {


        }

        public ElibraryDbContext()
        {
        }
    }
}
