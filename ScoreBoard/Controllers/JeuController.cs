using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScoreBoard.Models;

namespace ScoreBoard.Controllers
{
    public class JeuController : Controller
    {
        private readonly CatalogueJeuDbContext _context;

        public JeuController(CatalogueJeuDbContext context)
        {
            _context = context;
        }

        // GET: Jeu
        public async Task<IActionResult> Index()
        {
            var catalogueJeuDbContext = _context.Jeux.Include(j => j.Joueur);
            return View(await catalogueJeuDbContext.ToListAsync());
        }

        // GET: Jeu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jeux == null)
            {
                return NotFound();
            }

            var jeu = await _context.Jeux
                .Include(j => j.Joueur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jeu == null)
            {
                return NotFound();
            }

            return View(jeu);
        }

        // GET: Jeu/Create
        public IActionResult Create()
        {
            ViewData["JoueurId"] = new SelectList(_context.Joueurs, "Id", "Courriel");
            return View();
        }

        // POST: Jeu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,DateSortie,Description,JoueurId,ScoreJoueur,DateEnregistrement")] Jeu jeu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jeu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JoueurId"] = new SelectList(_context.Joueurs, "Id", "Courriel", jeu.JoueurId);
            return View(jeu);
        }

        // GET: Jeu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jeux == null)
            {
                return NotFound();
            }

            var jeu = await _context.Jeux.FindAsync(id);
            if (jeu == null)
            {
                return NotFound();
            }
            ViewData["JoueurId"] = new SelectList(_context.Joueurs, "Id", "Courriel", jeu.JoueurId);
            return View(jeu);
        }

        // POST: Jeu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,DateSortie,Description,JoueurId,ScoreJoueur,DateEnregistrement")] Jeu jeu)
        {
            if (id != jeu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jeu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JeuExists(jeu.Id))
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
            ViewData["JoueurId"] = new SelectList(_context.Joueurs, "Id", "Courriel", jeu.JoueurId);
            return View(jeu);
        }

        // GET: Jeu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jeux == null)
            {
                return NotFound();
            }

            var jeu = await _context.Jeux
                .Include(j => j.Joueur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jeu == null)
            {
                return NotFound();
            }

            return View(jeu);
        }

        // POST: Jeu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jeux == null)
            {
                return Problem("Entity set 'CatalogueJeuDbContext.Jeux'  is null.");
            }
            var jeu = await _context.Jeux.FindAsync(id);
            if (jeu != null)
            {
                _context.Jeux.Remove(jeu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JeuExists(int id)
        {
          return (_context.Jeux?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
