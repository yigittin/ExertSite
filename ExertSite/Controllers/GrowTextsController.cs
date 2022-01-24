using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExertSite.Data;
using ExertSite.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace ExertSite.Controllers
{
    [Authorize]

    public class GrowTextsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public GrowTextsController(ApplicationDbContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostEnvironment;
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
        public async Task<IActionResult> Create([Bind("GrowTextId,GrowtextImage,GrowHeader,Text")] GrowText growText)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, SiteOperations.GrowFolder);
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                growText.GrowtextImage = @"/" + fileName + extension;

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
        public async Task<IActionResult> Edit(int id, [Bind("GrowTextId,GrowtextImage,GrowHeader,Text")] GrowText growText)
        {
            if (id != growText.GrowTextId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var dbImage = _context.GrowText.FirstOrDefault(x => x.GrowTextId == growText.GrowTextId);
                    string webRootPath = _hostingEnvironment.WebRootPath;
                    string oldLink = "";
                    oldLink =webRootPath+@"/"+SiteOperations.GrowFolder+@"/"+dbImage.GrowtextImage.ToString();

                    var files = HttpContext.Request.Form.Files;
                    if (files.Count > 0)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        var uploads = Path.Combine(webRootPath, SiteOperations.GrowFolder);
                        var extension = Path.GetExtension(files[0].FileName);

                        using(var fileStream=new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        dbImage.GrowtextImage = fileName + extension;

                        if (System.IO.File.Exists(oldLink))
                        {
                            System.IO.File.Delete(oldLink);
                        }
                    }


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
            var webRootPath = _hostingEnvironment.WebRootPath;
            var growText = await _context.GrowText.FindAsync(id);
            string oldLink = "";
            oldLink = webRootPath + "@/" + SiteOperations.GrowFolder + @"/" + growText.GrowtextImage.ToString();
            if (System.IO.File.Exists(oldLink))
            {
                System.IO.File.Delete(oldLink);
            }

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
