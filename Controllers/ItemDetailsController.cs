using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMVC.Models;

namespace MyMVC.Controllers
{
    public class ItemDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItemDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductsTB.ToListAsync());
        }

        // GET: ItemDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemDetails = await _context.ProductsTB
                .SingleOrDefaultAsync(m => m.Item_ID == id);
            if (itemDetails == null)
            {
                return NotFound();
            }

            return View(itemDetails);
        }

        // GET: ItemDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Item_ID,Item_Name,Item_Price,Image_Name,Description")] ItemDetails itemDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemDetails);
        }

        // GET: ItemDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemDetails = await _context.ProductsTB.SingleOrDefaultAsync(m => m.Item_ID == id);
            if (itemDetails == null)
            {
                return NotFound();
            }
            return View(itemDetails);
        }

        // POST: ItemDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Item_ID,Item_Name,Item_Price,Image_Name,Description")] ItemDetails itemDetails)
        {
            if (id != itemDetails.Item_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemDetailsExists(itemDetails.Item_ID))
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
            return View(itemDetails);
        }

        // GET: ItemDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemDetails = await _context.ProductsTB
                .SingleOrDefaultAsync(m => m.Item_ID == id);
            if (itemDetails == null)
            {
                return NotFound();
            }

            return View(itemDetails);
        }

        // POST: ItemDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemDetails = await _context.ProductsTB.SingleOrDefaultAsync(m => m.Item_ID == id);
            _context.ProductsTB.Remove(itemDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemDetailsExists(int id)
        {
            return _context.ProductsTB.Any(e => e.Item_ID == id);
        }
    }
}
