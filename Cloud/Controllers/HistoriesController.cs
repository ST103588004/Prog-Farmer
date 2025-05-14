using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cloud.Models;

namespace Cloud.Controllers
{
    public class HistoriesController : Controller
    {
        private readonly ApplicationBBContext _context;

        public HistoriesController(ApplicationBBContext context)
        {
            _context = context;
        }

        // GET: Histories
        public async Task<IActionResult> Index()
        {
            return View(await _context.History.ToListAsync());
        }

        // GET: Histories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var history = await _context.History.FirstOrDefaultAsync(m => m.HistoryID == id);
            if (history == null) return NotFound();

            return View(history);
        }

        // GET: Histories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Histories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoryID,Email,productID,ProductName,ShippingAddress,ShippingStatus,HistoryDate")] History history)
        {
            if (ModelState.IsValid)
            {
                _context.Add(history);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(history);
        }

        // GET: Histories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var history = await _context.History.FindAsync(id);
            if (history == null) return NotFound();

            return View(history);
        }

        // POST: Histories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoryID,Email,productID,ProductName,ShippingAddress,ShippingStatus,HistoryDate")] History history)
        {
            if (id != history.HistoryID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(history);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoryExists(history.HistoryID))
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
            return View(history);
        }

        // GET: Histories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var history = await _context.History.FirstOrDefaultAsync(m => m.HistoryID == id);
            if (history == null) return NotFound();

            return View(history);
        }

        // POST: Histories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var history = await _context.History.FindAsync(id);
            if (history != null)
            {
                _context.History.Remove(history);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool HistoryExists(int id)
        {
            return _context.History.Any(e => e.HistoryID == id);
        }
    }
}
