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
           modelBuilder.Entity<BookGenre>().HasKey(bg=>new {bg.GenreId,bg.BookId});
           modelBuilder.Entity<BookGenre>().HasOne(bg=>bg.Book).WithMany(bg=>bg.Genres).HasForeignKey(bg=>bg.GenreId).OnDelete(DeleteBehavior.NoAction);
           modelBuilder.Entity<BookGenre>().HasOne(bg => bg.Genre).WithMany(bg => bg.Books).HasForeignKey(bg => bg.BookId).OnDelete(DeleteBehavior.NoAction); 
            modelBuilder.Entity<BookIssue>().HasKey(bi => new { bi.MemberId, bi.BookId,bi.IssueDate,bi.DueDate });
            modelBuilder.Entity<BookIssue>().HasOne(bi => bi.Member).WithMany(bi => bi.Books).HasForeignKey(bi => bi.BookId);
            modelBuilder.Entity<BookIssue>().HasOne(bi => bi.Book).WithMany(bi => bi.Members).HasForeignKey(bi => bi.MemberId);
        }
    }
}
