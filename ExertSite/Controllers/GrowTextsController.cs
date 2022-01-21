using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExertSite.Data;
using ExertSite.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ExertSite.Controllers
{
    public class GrowTextsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public GrowTextsController(ApplicationDbContext context,IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: GrowTexts
        public async Task<IActionResult> Index()
        {
            return View(await _context.GrowText.ToListAsync());
        }

        // GET: GrowTexts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var growText = await _context.GrowText
                .FirstOrDefaultAsync(m => m.GrowTextId == id);
            if (growText == null)
            {
                return NotFound();
            }

            return View(growText);
        }

        // GET: GrowTexts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GrowTexts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GrowTextId,Text,GrowtextImage")] GrowText growText)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images/grows");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                growText.GrowtextImage = @"/images/grows/" + fileName + extension;

                _context.Add(growText);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(growText);
        }

        // GET: GrowTexts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var growText = await _context.GrowText.FindAsync(id);
            if (growText == null)
            {
                return NotFound();
            }
            return View(growText);
        }

        // POST: GrowTexts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GrowTextId,Text,GrowtextImage")] GrowText growText)
        {
            if (id != growText.GrowTextId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(growText);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrowTextExists(growText.GrowTextId))
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
            return View(growText);
        }

        // GET: GrowTexts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var growText = await _context.GrowText
                .FirstOrDefaultAsync(m => m.GrowTextId == id);
            if (growText == null)
            {
                return NotFound();
            }

            return View(growText);
        }

        // POST: GrowTexts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var growText = await _context.GrowText.FindAsync(id);
            _context.GrowText.Remove(growText);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrowTextExists(int id)
        {
            return _context.GrowText.Any(e => e.GrowTextId == id);
        }
    }
}
