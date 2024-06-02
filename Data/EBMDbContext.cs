using BookManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagment.Data
{
    public class EBMDbContext:DbContext
    {
        public DbSet<Book> books { get; set; }
        public DbSet<BookIssue> bookIssues { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Publisher> publishers { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Member> members { get; set; }

        public EBMDbContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
