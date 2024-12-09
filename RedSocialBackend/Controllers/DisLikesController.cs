using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RedSocialBackend.DataContext;
using RedSocialServices.Models;

namespace RedSocialBackend.Controllers
{
    public class DisLikesController : Controller
    {
        private readonly RedSocialContext _context;

        public DisLikesController(RedSocialContext context)
        {
            _context = context;
        }

        // GET: DisLikes
        public async Task<IActionResult> Index()
        {
            var redSocialContext = _context.DisLikes.Include(d => d.Publicacion).Include(d => d.Usuario);
            return View(await redSocialContext.ToListAsync());
        }

        // GET: DisLikes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disLike = await _context.DisLikes
                .Include(d => d.Publicacion)
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disLike == null)
            {
                return NotFound();
            }

            return View(disLike);
        }

        // GET: DisLikes/Create
        public IActionResult Create()
        {
            ViewData["PublicacionId"] = new SelectList(_context.Publicaciones, "Id", "Contenido");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "NombreApodo");
            return View();
        }

        // POST: DisLikes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,PublicacionId,Eliminado")] DisLike disLike)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disLike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PublicacionId"] = new SelectList(_context.Publicaciones, "Id", "Contenido", disLike.PublicacionId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "NombreApodo", disLike.UsuarioId);
            return View(disLike);
        }

        // GET: DisLikes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disLike = await _context.DisLikes.FindAsync(id);
            if (disLike == null)
            {
                return NotFound();
            }
            ViewData["PublicacionId"] = new SelectList(_context.Publicaciones, "Id", "Contenido", disLike.PublicacionId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "NombreApodo", disLike.UsuarioId);
            return View(disLike);
        }

        // POST: DisLikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,PublicacionId,Eliminado")] DisLike disLike)
        {
            if (id != disLike.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disLike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisLikeExists(disLike.Id))
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
            ViewData["PublicacionId"] = new SelectList(_context.Publicaciones, "Id", "Contenido", disLike.PublicacionId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "NombreApodo", disLike.UsuarioId);
            return View(disLike);
        }

        // GET: DisLikes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disLike = await _context.DisLikes
                .Include(d => d.Publicacion)
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disLike == null)
            {
                return NotFound();
            }

            return View(disLike);
        }

        // POST: DisLikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disLike = await _context.DisLikes.FindAsync(id);
            if (disLike != null)
            {
                _context.DisLikes.Remove(disLike);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisLikeExists(int id)
        {
            return _context.DisLikes.Any(e => e.Id == id);
        }
    }
}
