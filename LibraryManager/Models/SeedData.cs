using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new LibraryManagerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LibraryManagerContext>>());

            if (context.Category.Any())
            {
                return; // DB has already been seeded
            }

            context.Category.AddRange(
                new Category()
                {
                    CategoryName = "Fantasy"
                }, 
                new Category()
                {
                    CategoryName = "Adventure"
                },
                new Category()
                {
                    CategoryName = "Romance"
                }
            );

            if (context.LibraryItem.Any())
            {
                return;   // DB has already been seeded
            }

            context.LibraryItem.AddRange(
                new LibraryItem()
                {
                    Title = "Lord of The Rings",
                    Author = "J R R Tolkien",
                    Pages = 123,
                    RunTimeMinutes = null,
                    IsBorrowable = 1,
                    Borrower = null,
                    BorrowDate = null,
                    Type = "Book",
                    CategoryId = 1
                },
                new LibraryItem()
                {
                    Title = "Gone With The Wind",
                    Author = "Margaret Mitchell",
                    Pages = null,
                    RunTimeMinutes = 234,
                    IsBorrowable = 1,
                    Borrower = null,
                    BorrowDate = null,
                    Type = "DVD",
                    CategoryId = 3
                },
                new LibraryItem()
                {
                    Title = "Fool's Fate",
                    Author = "Robin Hobb",
                    Pages = null,
                    RunTimeMinutes = 345,
                    IsBorrowable = 1,
                    Borrower = "",
                    BorrowDate = null,
                    Type = "Audio Book",
                    CategoryId = 2
                },
                new LibraryItem()
                {
                    Title = "Fantasy Encyclopedia",
                    Author = "Mary Merry",
                    Pages = 123,
                    RunTimeMinutes = null,
                    IsBorrowable = 0, // should always be false - Can only be read at the library
                    Borrower = "",
                    BorrowDate = null,
                    Type = "Reference Book",
                    CategoryId = 1
                }
            );
            context.SaveChanges();
        }
    }
}
