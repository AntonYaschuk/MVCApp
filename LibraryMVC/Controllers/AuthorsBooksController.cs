using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryMVC;

namespace LibraryMVC.Controllers
{
    public class AuthorsBooksController : Controller
    {
        private readonly DBLibraryContext _context;

        public AuthorsBooksController(DBLibraryContext context)
        {
            _context = context;
        }

        // GET: AuthorsBooks
        public async Task<IActionResult> Index()
        {
            var dBLibraryContext = _context.AuthorsBooks.Include(a => a.Author).Include(a => a.Book);
            return View(await dBLibraryContext.ToListAsync());
        }

        // GET: AuthorsBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorsBooks = await _context.AuthorsBooks
                .Include(a => a.Author)
                .Include(a => a.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authorsBooks == null)
            {
                return NotFound();
            }

            return View(authorsBooks);
        }

        // GET: AuthorsBooks/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name");
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name");
            return View();
        }

        // POST: AuthorsBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,AuthorId,Id")] AuthorsBooks authorsBooks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorsBooks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", authorsBooks.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name", authorsBooks.BookId);
            return View(authorsBooks);
        }

        // GET: AuthorsBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorsBooks = await _context.AuthorsBooks.FindAsync(id);
            if (authorsBooks == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", authorsBooks.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name", authorsBooks.BookId);
            return View(authorsBooks);
        }

        // POST: AuthorsBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,AuthorId,Id")] AuthorsBooks authorsBooks)
        {
            if (id != authorsBooks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorsBooks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorsBooksExists(authorsBooks.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", authorsBooks.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name", authorsBooks.BookId);
            return View(authorsBooks);
        }

        // GET: AuthorsBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorsBooks = await _context.AuthorsBooks
                .Include(a => a.Author)
                .Include(a => a.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authorsBooks == null)
            {
                return NotFound();
            }

            return View(authorsBooks);
        }

        // POST: AuthorsBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authorsBooks = await _context.AuthorsBooks.FindAsync(id);
            _context.AuthorsBooks.Remove(authorsBooks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorsBooksExists(int id)
        {
            return _context.AuthorsBooks.Any(e => e.Id == id);
        }
    }
}
