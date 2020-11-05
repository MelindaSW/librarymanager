using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Repos
{
    public interface ILibraryItemRepo
    {
        Task<List<LibraryItem>> GetAllLibraryItems();
        Task<LibraryItem> GetOneItem(int? id);
        void CreateItem(LibraryItem item);
        DbSet<Category> GetCategories();
        bool CheckIfItemExists(int id);
        void UpdateLibraryItem(LibraryItem item);
        void DeleteLibraryItem(int id);
    }
}
