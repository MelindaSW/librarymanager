using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Data
{
    public class LibraryManagerContext : DbContext
    {
        public LibraryManagerContext(DbContextOptions<LibraryManagerContext> options) : base(options)
        {
        }
        // Add entity sets for the tables here
        public DbSet<Employee> Employee { get; set; }
    }
}
