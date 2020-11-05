using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Models;
using LibraryManager.Repos;

namespace LibraryManager.Services
{
    public class CategoryServiceImpl : ICategoryService
    {
        private readonly ICategoryRepo _repo;

        public CategoryServiceImpl(ICategoryRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _repo.GetAllCategories();
        }

        public async Task<Category> GetOneCategory(int? id)
        {
            return await _repo.GetOneCategory(id);
        }

        public async Task CreateCategory(Category category)
        {
            await _repo.CreateCategory(category);
        }

        public async Task UpdateCategory(Category category)
        {
            await _repo.UpdateCategory(category);
        }

        public bool CheckIfCategoryExists(int id)
        {
            return _repo.CheckIfCategoryExists(id);
        }

        public async Task DeleteCategory(int id)
        {
            await _repo.DeleteCategory(id);
        }
    }
}
