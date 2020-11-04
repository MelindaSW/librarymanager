using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManager.Models;
using NUnit.Framework;

namespace LibraryManager.Services
{
    public interface ILibraryItemService
    {
        Task<List<LibraryItem>> GetAllLibraryItems();
    }
}