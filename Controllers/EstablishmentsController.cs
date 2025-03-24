using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using _876Access.Data;
using _876Access.Models;
using Microsoft.AspNetCore.Authorization;

namespace _876Access.Controllers
{
    public class EstablishmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EstablishmentsController(ApplicationDbContext context,IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;
        }

        // GET: Establishments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Establishments.ToListAsync());
        }

        // GET: Establishments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var establishments = await _context.Establishments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (establishments == null)
            {
                return NotFound();
            }

            return View(establishments);
        }

        // GET: Establishments/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }


        private string UploadedFile(Establishments establishments)
        {
            string uniqueFileName = null;
            if (establishments.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + establishments.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    establishments.ImageFile.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }



        // POST: Establishments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Establishments establishments)
        {
            string uniqueFileName = UploadedFile(establishments);
            establishments.FileName = uniqueFileName;
            _context.Attach(establishments);
            _context.Entry(establishments).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Establishments/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var establishments = await _context.Establishments.FindAsync(id);
            if (establishments == null)
            {
                return NotFound();
            }
            return View(establishments);
        }

        // POST: Establishments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,TeleNum,CellNum,Email,Website,Parish,Address,OpenHours,CloseHours,Description,ImageName")] Establishments establishments)
        {
            if (id != establishments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(establishments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstablishmentsExists(establishments.Id))
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
            return View(establishments);
        }

        // GET: Establishments/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var establishments = await _context.Establishments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (establishments == null)
            {
                return NotFound();
            }

            return View(establishments);
        }

        // POST: Establishments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var establishments = await _context.Establishments.FindAsync(id);
            if (establishments != null)
            {
                _context.Establishments.Remove(establishments);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstablishmentsExists(int id)
        {
            return _context.Establishments.Any(e => e.Id == id);
        }
    }
}
