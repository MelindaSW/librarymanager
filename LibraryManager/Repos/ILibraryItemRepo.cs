using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Models;

namespace LibraryManager.Repos
{
    public interface ILibraryItemRepo
    {
        Task<List<LibraryItem>> GetAllLibraryItems();
    }
}
