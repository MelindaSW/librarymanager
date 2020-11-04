using System.Collections.Generic;
using LibraryManager.Models;
using NUnit.Framework;

namespace LibraryManager.Services
{
    public interface ILibraryItemService
    {
        List<LibraryItem> GetAllLibraryItems();
    }
}