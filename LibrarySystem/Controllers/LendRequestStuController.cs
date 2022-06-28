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
    public class LendRequestStuController : Controller
    {
        private readonly LibraryManagementContext _context;

        public LendRequestStuController(LibraryManagementContext context)
        {
            _context = context;
        }

        // GET: LendRequestStu
        public async Task<IActionResult> Index()
        {
            var libraryManagementContext = _context.LendRequest.Include(l => l.Book).Include(l => l.User);
            
            return View(await libraryManagementContext.ToListAsync());
        }

        // GET: LendRequestStu/Details/5
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

        // GET: LendRequestStu/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.BooksInfo, "BookId", "BookTitle");
            ViewData["UserId"] = new SelectList(_context.AccountsInfo, "UserId", "Username");
            
            return View();
        }

        // POST: LendRequestStu/Create
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

        // GET: LendRequestStu/Edit/5
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

        // POST: LendRequestStu/Edit/5
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

        // GET: LendRequestStu/Delete/5
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

        // POST: LendRequestStu/Delete/5
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
        public IActionResult Return(int id)
        {
            DateTime date = DateTime.Today;
            string connect;
            SqlConnection cnn;
 
            //connect = "Server=localhost;Database=LibraryManagement;Trusted_Connection=True";
            connect = "Server= . ;Database=LibraryManagement;Trusted_Connection=True";

            cnn = new SqlConnection(connect);

            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter=new SqlDataAdapter();
            string sql;
            DateTime output;

            
            sql = $"Update LendRequest set ReturnDate='{date}' where LendId={id}";
            command = new SqlCommand(sql, cnn);
            
            adapter.UpdateCommand = new SqlCommand(sql, cnn);
            //adapter.UpdateCommand.ExecuteNonQuery();
            command.Dispose();

            sql = $"Select LendDate From LendRequest Where LendId={id}";
            command = new SqlCommand(sql, cnn);


            output = (DateTime)command.ExecuteScalar();

            command.Dispose();

            int diff = (int)(date - output).TotalDays;
            float fine = diff * 10;

            sql = $"Update LendRequest set FineAmount={fine} where LendId={id}";

            command = new SqlCommand(sql, cnn);
           
            adapter.UpdateCommand = new SqlCommand(sql, cnn);
            adapter.UpdateCommand.ExecuteNonQuery();
            command.Dispose();

            cnn.Close();

            return RedirectToAction("Index", "LendRequestStu");
        }

        [HttpGet]
        public IActionResult GetBooksInfo()
        {
            return RedirectToAction("Index", "BooksInfoStu");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");

            return RedirectToAction("Index","Home");
        }


    }
}
