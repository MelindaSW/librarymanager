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

        public async Task<LibraryItem> GetOneItem(int? id)
        {
            var libraryItem = await _context.LibraryItem
                .Include(l => l.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            return libraryItem;
        }

        public async void CreateItem(LibraryItem item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
        }

        public DbSet<Category> GetCategories()
        {
            return _context.Category;
        }

        public bool CheckIfItemExists(int id)
        {
            return _context.LibraryItem.Any(e => e.Id == id);
        }

        public async void UpdateLibraryItem(LibraryItem item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async void DeleteLibraryItem(int id)
        {
            var libraryItem = await _context.LibraryItem.FindAsync(id);
            _context.LibraryItem.Remove(libraryItem);
            await _context.SaveChangesAsync();
        }
    }
}