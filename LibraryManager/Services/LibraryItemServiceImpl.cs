using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Models;
using LibraryManager.Repos;

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


        private string GetAcronym(string s)
        {
            var splitString = s.Split(" ");
            return splitString.Aggregate("", (current, word) => current + char.ToUpper(word[0]));
        }
    }
}
 