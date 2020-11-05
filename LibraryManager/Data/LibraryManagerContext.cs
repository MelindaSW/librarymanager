using LibraryManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Data
{
    public class LibraryManagerContext : DbContext
    {
        public LibraryManagerContext(DbContextOptions<LibraryManagerContext> options) : base(options)
        { 
        }
        
        public DbSet<LibraryItem> LibraryItem { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Category { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasIndex(p => new { p.CategoryName })
                .IsUnique();
        }
    }
}
