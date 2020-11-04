using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Models;
using LibraryManager.Repos;

namespace LibraryManager.Services
{
    public class LibraryItemServiceImpl : ILibraryItemService
    {
        private readonly LibraryItemRepo _repo;
        public LibraryItemServiceImpl(LibraryItemRepo repo)
        {
            _repo = repo;
        }

        public List<LibraryItem> GetAllLibraryItems()
        {
            throw new NotImplementedException();
        }
    }
}
 