using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Models;
using LibraryManager.Repos;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Services
{
    public class LibraryItemServiceImpl : ILibraryItemService
    {
        private readonly ILibraryItemRepo _repo;

        public LibraryItemServiceImpl(ILibraryItemRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<LibraryItem>> GetAllLibraryItems()
        {
            var libraryItems = await _repo.GetAllLibraryItems();
            // For every title in the list concat the title with its acronym
            foreach (var item in libraryItems)
            {
                item.Title = string.Concat(item.Title, " (" + GetAcronym(item.Title) + ") ");
            }
            return libraryItems;
        }

        public async Task<LibraryItem> GetOneItem(int? id)
        {
            var item = await _repo.GetOneItem(id);
            return item;
        }

        public async Task CreateItem(LibraryItem item)
        {
            await _repo.CreateItem(item);
        }

        public DbSet<Category> GetCategories()
        {
            return _repo.GetCategories();
        }

        public bool CheckIfItemExists(int id)
        {
            return _repo.CheckIfItemExists(id);
        }

        public async Task UpdateLibraryItem(LibraryItem item)
        {
            await _repo.UpdateLibraryItem(item);
        }

        public async Task DeleteLibraryItem(int id)
        {
           await _repo.DeleteLibraryItem(id);
        }

        private static string GetAcronym(string s)
        {
            var splitString = s.Split(" ");
            return splitString.Aggregate("", (current, word) => current + char.ToUpper(word[0]));
        }
    }
}
 