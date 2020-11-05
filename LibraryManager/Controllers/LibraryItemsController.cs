using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryManager.Models;
using LibraryManager.Services;

namespace LibraryManager.Controllers
{
    public class LibraryItemsController : Controller
    {
        private readonly ILibraryItemService _service;

        public LibraryItemsController(ILibraryItemService service)
        {
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
            ViewData["CategoryId"] = new SelectList(_service.GetCategories(), "Id", "Id");
            return View();
        }

        // POST: LibraryItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Pages,RunTimeMinutes,IsBorrowable,Borrower,BorrowDate,Type,CategoryId")] LibraryItem libraryItem)
        {
            if (ModelState.IsValid)
            {
               await _service.CreateItem(libraryItem);   
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

            var libraryItem = await _service.GetOneItem(id);
            if (libraryItem == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_service.GetCategories(), "Id", "Id", libraryItem.CategoryId);
            return View(libraryItem);
        }

        // POST: LibraryItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Pages,RunTimeMinutes,IsBorrowable,Borrower,BorrowDate,Type,CategoryId")] LibraryItem libraryItem)
        {
            if (id != libraryItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                if (!_service.CheckIfItemExists(id))
                {
                    return NotFound();
                }

                await _service.UpdateLibraryItem(libraryItem);
                
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteLibraryItem(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
