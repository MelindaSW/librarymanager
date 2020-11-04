using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Data;

namespace LibraryManager.Repos
{
    public class LibraryItemRepo
    {

        private readonly LibraryManagerContext _context;

        public LibraryItemRepo(LibraryManagerContext context)
        {
            _context = context;
        }
    }
}