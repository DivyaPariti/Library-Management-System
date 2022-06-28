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
    public class AccountsInfoController : Controller
    {
        private readonly LibraryManagementContext _context;

        public AccountsInfoController(LibraryManagementContext context)
        {
            _context = context;
        }

        // GET: AccountsInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountsInfo.ToListAsync());
        }

        // GET: AccountsInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountsInfo = await _context.AccountsInfo
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (accountsInfo == null)
            {
                return NotFound();
            }

            return View(accountsInfo);
        }

        // GET: AccountsInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountsInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Username,Psd,AccountType")] AccountsInfo accountsInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountsInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountsInfo);
        }

        // GET: AccountsInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountsInfo = await _context.AccountsInfo.FindAsync(id);
            if (accountsInfo == null)
            {
                return NotFound();
            }
            return View(accountsInfo);
        }

        // POST: AccountsInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Username,Psd,AccountType")] AccountsInfo accountsInfo)
        {
            if (id != accountsInfo.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountsInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountsInfoExists(accountsInfo.UserId))
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
            return View(accountsInfo);
        }

        // GET: AccountsInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountsInfo = await _context.AccountsInfo
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (accountsInfo == null)
            {
                return NotFound();
            }

            return View(accountsInfo);
        }

        // POST: AccountsInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountsInfo = await _context.AccountsInfo.FindAsync(id);
            _context.AccountsInfo.Remove(accountsInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountsInfoExists(int id)
        {
            return _context.AccountsInfo.Any(e => e.UserId == id);
        }

        [HttpGet]
        public IActionResult GetBooksInfo()
        {
            return RedirectToAction("Index", "BooksInfo");
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
