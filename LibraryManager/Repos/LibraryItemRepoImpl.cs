using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Data;
using LibraryManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Repos
{
    public class LibraryItemRepoImpl : ILibraryItemRepo
    {

        private readonly LibraryManagerContext _context;

        public LibraryItemRepoImpl(LibraryManagerContext context)
        {
            _context = context;
        }

        public async Task<List<LibraryItem>> GetAllLibraryItems()
        {
            var allLibraryItems = await _context.LibraryItem.Include(l => l.Category).OrderBy(n => n.Category.CategoryName).ToListAsync();
            return allLibraryItems;
        }
    }
}