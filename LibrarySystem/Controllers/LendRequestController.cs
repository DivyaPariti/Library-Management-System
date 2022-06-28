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
    public class LendRequestController : Controller
    {
        private readonly LibraryManagementContext _context;

        public LendRequestController(LibraryManagementContext context)
        {
            _context = context;
        }

        // GET: LendRequest
        public async Task<IActionResult> Index()
        {
            var libraryManagementContext = _context.LendRequest.Include(l => l.Book).Include(l => l.User);
            return View(await libraryManagementContext.ToListAsync());
        }

        // GET: LendRequest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lendRequest = await _context.LendRequest
                .Include(l => l.Book)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.LendId == id);
            if (lendRequest == null)
            {
                return NotFound();
            }

            return View(lendRequest);
        }

        // GET: LendRequest/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.BooksInfo, "BookId", "BookTitle");
            ViewData["UserId"] = new SelectList(_context.AccountsInfo, "UserId", "Username");
            return View();
        }

        // POST: LendRequest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LendId,BookId,LendDate,ReturnDate,FineAmount,UserId,ReqStatus")] LendRequest lendRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lendRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.BooksInfo, "BookId", "BookTitle", lendRequest.BookId);
            ViewData["UserId"] = new SelectList(_context.AccountsInfo, "UserId", "Username", lendRequest.UserId);
            return View(lendRequest);
        }

        // GET: LendRequest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lendRequest = await _context.LendRequest.FindAsync(id);
            if (lendRequest == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.BooksInfo, "BookId", "BookTitle", lendRequest.BookId);
            ViewData["UserId"] = new SelectList(_context.AccountsInfo, "UserId", "Username", lendRequest.UserId);
            return View(lendRequest);
        }

        // POST: LendRequest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LendId,BookId,LendDate,ReturnDate,FineAmount,UserId,ReqStatus")] LendRequest lendRequest)
        {
            if (id != lendRequest.LendId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lendRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LendRequestExists(lendRequest.LendId))
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
            ViewData["BookId"] = new SelectList(_context.BooksInfo, "BookId", "BookTitle", lendRequest.BookId);
            ViewData["UserId"] = new SelectList(_context.AccountsInfo, "UserId", "Username", lendRequest.UserId);
            return View(lendRequest);
        }

        // GET: LendRequest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lendRequest = await _context.LendRequest
                .Include(l => l.Book)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.LendId == id);
            if (lendRequest == null)
            {
                return NotFound();
            }

            return View(lendRequest);
        }

        // POST: LendRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lendRequest = await _context.LendRequest.FindAsync(id);
            _context.LendRequest.Remove(lendRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LendRequestExists(int id)
        {
            return _context.LendRequest.Any(e => e.LendId == id);
        }

        [HttpGet]
        public IActionResult GetBooksInfo()
        {
            return RedirectToAction("Index", "BooksInfo");
        }

        [HttpGet]
        public IActionResult GetAccountsInfo()
        {
            return RedirectToAction("Index", "AccountsInfo");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");

            return RedirectToAction("Index", "Home");
        }
    }
}
