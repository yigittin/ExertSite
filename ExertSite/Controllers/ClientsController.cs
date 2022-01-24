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

    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ClientsController(ApplicationDbContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Client.ToListAsync());
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clients = await _context.Client
                .FirstOrDefaultAsync(m => m.ClientsId == id);
            if (clients == null)
            {
                return NotFound();
            }

            return View(clients);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientsId,ClientImage")] Clients clients)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, SiteOperations.ClientFolder);
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                clients.ClientImage = @"/" + fileName + extension;

                _context.Add(clients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clients);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clients = await _context.Client.FindAsync(id);
            if (clients == null)
            {
                return NotFound();
            }
            return View(clients);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientsId,ClientImage")] Clients clients)
        {
            if (id != clients.ClientsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string webRootPath = _hostEnvironment.WebRootPath;

                    string oldLink = "";
                    var dbImage = _context.Client.FirstOrDefault(x => x.ClientsId == clients.ClientsId);
                                      

                    oldLink = webRootPath+@"/"+ SiteOperations.ClientFolder+@"/"+ dbImage.ClientImage.ToString();
                   
                    oldLink = "";
                    

                    var files = HttpContext.Request.Form.Files;
                    if (files.Count > 0)
                    {

                        string fileName = Guid.NewGuid().ToString();
                        var uploads = Path.Combine(webRootPath, SiteOperations.SliderFolder);
                        var extension = Path.GetExtension(files[0].FileName);

                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        dbImage.ClientImage = @"/"+fileName + extension;
                        if (System.IO.File.Exists(oldLink))
                        {
                            System.IO.File.Delete(oldLink);
                        }
                    }
                    
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientsExists(clients.ClientsId))
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
            return View(clients);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
        

            var clients = await _context.Client
                .FirstOrDefaultAsync(m => m.ClientsId == id);
            if (clients == null)
            {
                return NotFound();
            }

            return View(clients);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clients = await _context.Client.FindAsync(id);
            var webRootPath = _hostEnvironment.WebRootPath;
            var dbImage = _context.Client.FirstOrDefault(x => x.ClientsId == clients.ClientsId);
            var oldLink = webRootPath + @"/" + SiteOperations.ClientFolder + @"/" + dbImage.ClientImage.ToString();
            if (System.IO.File.Exists(oldLink))
            {
                System.IO.File.Delete(oldLink);
            }
            _context.Client.Remove(clients);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientsExists(int id)
        {
            return _context.Client.Any(e => e.ClientsId == id);
        }
    }
}
