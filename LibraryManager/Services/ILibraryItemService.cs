using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManager.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace LibraryManager.Services
{
    public interface ILibraryItemService
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