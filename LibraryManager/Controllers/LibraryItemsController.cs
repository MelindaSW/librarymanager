using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManager.Data;
using LibraryManager.Models;
using LibraryManager.Services;

namespace LibraryManager.Controllers
{
    public class LibraryItemsController : Controller
    {
        private readonly LibraryManagerContext _context;
        private readonly ILibraryItemService _service;

        public LibraryItemsController(LibraryManagerContext context, ILibraryItemService service)
        {
            _context = context;
            _service = service;
        }

        // GET: LibraryItems
        public async Task<IActionResult> Index()
        {
            var allLibraryItems = await _service.GetAllLibraryItems();
            return View(allLibraryItems);
        }

        // GET: LibraryItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryItem = await _service.GetOneItem(id);

            if (libraryItem == null)
            {
                return NotFound();
            }

            return View(libraryItem);
        }

        // GET: LibraryItems/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id");
            return View();
        }

        // POST: LibraryItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Author,Pages,RunTimeMinutes,IsBorrowable,Borrower,BorrowDate,Type,CategoryId")] LibraryItem libraryItem)
        {
            if (ModelState.IsValid)
            {
                _service.CreateItem(libraryItem);   
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_service.GetCategories(), "Id", "Id", libraryItem.CategoryId);
            return View(libraryItem);
        }

        // GET: LibraryItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryItem = await _context.LibraryItem.FindAsync(id);
            if (libraryItem == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", libraryItem.CategoryId);
            return View(libraryItem);
        }

        // POST: LibraryItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Author,Pages,RunTimeMinutes,IsBorrowable,Borrower,BorrowDate,Type,CategoryId")] LibraryItem libraryItem)
        {
            if (id != libraryItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.UpdateLibraryItem(libraryItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.CheckIfItemExists(id))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_service.GetCategories(), "Id", "Id", libraryItem.CategoryId);
            return View(libraryItem);
        }

        // GET: LibraryItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var libraryItem = await _service.GetOneItem(id);
            if (libraryItem == null)
            {
                return NotFound();
            }

            return View(libraryItem);
        }

        // POST: LibraryItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.DeleteLibraryItem(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
