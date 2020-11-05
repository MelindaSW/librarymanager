using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Data;
using LibraryManager.Migrations;
using LibraryManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Repos
{
    public class CategoryRepoImpl : ICategoryRepo
    {
        private readonly LibraryManagerContext _context;

        public CategoryRepoImpl(LibraryManagerContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> GetOneCategory(int? id)
        {
            return await _context.Category
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task CreateCategory(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
        }

        public bool CheckIfCategoryExists(int id)
        {
            return _context.Category.Any(e => e.Id == id);
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
