using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cloud.Data;
using Cloud.Models;
using Microsoft.AspNetCore.Identity;

namespace Cloud.Controllers
{
  
    public class MyWorksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ApplicationBBContext _historyycontext;
        private readonly UserManager<IdentityUser> _UserManger;


        public MyWorksController(ApplicationDbContext context, ApplicationBBContext historyycontext, UserManager<IdentityUser> UserManger)
        {
            _context = context;
            _historyycontext = historyycontext;
            _UserManger = UserManger;
        }

        // GET: MyWorks
        public async Task<IActionResult> Index(string searchTerm)
        {
            IQueryable<MyWork> works = _context.MyWork;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.Trim();
                works = works.Where(w => w.Name.Contains(searchTerm) || w.Category.Contains(searchTerm));
            }

            return View(await works.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> SearchAsync(string searchTerm)
        {
            IQueryable<MyWork> works = _context.MyWork;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.Trim();
                works = works.Where(w => w.Name.Contains(searchTerm) || w.Category.Contains(searchTerm));
            }

            return Json(await works.ToListAsync()); // Return JSON for AJAX requests
        }


        // GET: MyWorks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myWork = await _context.MyWork
                .FirstOrDefaultAsync(m => m.productID == id);
            if (myWork == null)
            {
                return NotFound();
            }

            return View(myWork);
        }

        // GET: MyWorks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyWorks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("productID,Name,Price,Category,Availablility,ImageUrl")] MyWork myWork)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myWork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myWork);
        }
        public async Task<IActionResult> Display(int id)
        {

            var findProduct = _context.MyWork.Find(id);

            _historyycontext.Add(
                new History
                {

                    productID = id,
                    Email = _UserManger.GetUserName(this.User),
                    ShippingAddress = "21 Skibidi Place",
                    ShippingStatus = "Proccessing",
                    HistoryDate = DateTime.Now

                });
            _historyycontext.SaveChanges();
            return View(Display);
        }


        // GET: MyWorks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myWork = await _context.MyWork.FindAsync(id);
            if (myWork == null)
            {
                return NotFound();
            }
            return View(myWork);
        }

        // POST: MyWorks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("productID,Name,Price,Category,Availablility,ImageUrl")] MyWork myWork)
        {
            if (id != myWork.productID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myWork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyWorkExists(myWork.productID))
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
            return View(myWork);
        }


        // GET: MyWorks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myWork = await _context.MyWork
                .FirstOrDefaultAsync(m => m.productID == id);
            if (myWork == null)
            {
                return NotFound();
            }

            return View(myWork);
        }


        // POST: MyWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myWork = await _context.MyWork.FindAsync(id);
            if (myWork != null)
            {
                _context.MyWork.Remove(myWork);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyWorkExists(int id)
        {
            return _context.MyWork.Any(e => e.productID == id);
        }
    }
}
