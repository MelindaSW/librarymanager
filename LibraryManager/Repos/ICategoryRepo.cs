using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Models;

namespace LibraryManager.Repos
{
    public interface ICategoryRepo
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetOneCategory(int? id);
        Task CreateCategory(Category category);
        Task UpdateCategory(Category category);
        bool CheckIfCategoryExists(int id);
        Task DeleteCategory(int id);
    }
}
