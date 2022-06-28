using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;

namespace LibrarySystem.Controllers
{
    public class BooksInfoStuController : Controller
    {
        private readonly LibraryManagementContext _context;

        public BooksInfoStuController(LibraryManagementContext context)
        {
            _context = context;
        }

        // GET: BooksInfoStu
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

        // GET: BooksInfoStu/Details/5
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

        // GET: BooksInfoStu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BooksInfoStu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,BookTitle,Author,Genre,NumberofCopies")] BooksInfo booksInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booksInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(booksInfo);
        }

        // GET: BooksInfoStu/Edit/5
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

        // POST: BooksInfoStu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,BookTitle,Author,Genre,NumberofCopies")] BooksInfo booksInfo)
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

        // GET: BooksInfoStu/Delete/5
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

        // POST: BooksInfoStu/Delete/5
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
        public IActionResult MakeReq()
        {
            return RedirectToAction("Index", "LendRequestStu");
        }

        [HttpGet]
        public IActionResult RequestBook(int id)
        {
            DateTime date = DateTime.Now;
            string connect;
            SqlConnection cnn;

            connect = "Server= . ;Database=LibraryManagement;Trusted_Connection=True";

            cnn = new SqlConnection(connect);

            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql;


            sql = $"Insert into LendRequest values ({id},'{date}',NULL,NULL,1,'Pending');";
            command = new SqlCommand(sql, cnn);

            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            cnn.Close();

            return RedirectToAction("Index", "LendRequestStu");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");

            return RedirectToAction("Index", "Home");
        }


    }
}
