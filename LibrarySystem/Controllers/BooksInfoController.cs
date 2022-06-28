using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Http;

namespace LibrarySystem.Controllers
{
    public class BooksInfoController : Controller
    {
        private readonly LibraryManagementContext _context;

        public BooksInfoController(LibraryManagementContext context)
        {
            _context = context;
        }

        // GET: BooksInfo
        public async Task<IActionResult> Index(string SearchString)
        {
            var books = from b in _context.BooksInfo
                        select b;

            if (!String.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => s.BookTitle.Contains(SearchString) || s.Author.Contains(SearchString) || s.Genre.Contains(SearchString));
            }
            return View(await books.ToListAsync());
        }

        // GET: BooksInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booksInfo = await _context.BooksInfo
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (booksInfo == null)
            {
                return NotFound();
            }

            return View(booksInfo);
        }

        // GET: BooksInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BooksInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,BookTitle,Author,Genre,NumberofCopies,ImageUrl")] BooksInfo booksInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booksInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(booksInfo);
        }

        // GET: BooksInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booksInfo = await _context.BooksInfo.FindAsync(id);
            if (booksInfo == null)
            {
                return NotFound();
            }
            return View(booksInfo);
        }

        // POST: BooksInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,BookTitle,Author,Genre,NumberofCopies,ImageUrl")] BooksInfo booksInfo)
        {
            if (id != booksInfo.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booksInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksInfoExists(booksInfo.BookId))
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
            return View(booksInfo);
        }

        // GET: BooksInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booksInfo = await _context.BooksInfo
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (booksInfo == null)
            {
                return NotFound();
            }

            return View(booksInfo);
        }

        // POST: BooksInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booksInfo = await _context.BooksInfo.FindAsync(id);
            _context.BooksInfo.Remove(booksInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BooksInfoExists(int id)
        {
            return _context.BooksInfo.Any(e => e.BookId == id);
        }

        [HttpGet]
        public IActionResult GetAccountInfo()
        {
            return RedirectToAction("Index", "AccountsInfo");
        }

        [HttpGet]
        public IActionResult GetRequestInfo()
        {
            return RedirectToAction("Index", "LendRequest");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");

            return RedirectToAction("Index", "Home");
        }
    }
}
