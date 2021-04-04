using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameLibraryNetCore.Models;

namespace GameLibraryNetCore.Controllers
{
    public class GameLibrariesController : Controller
    {
        private readonly GameLibraryContext _context;

        public GameLibrariesController(GameLibraryContext context)
        {
            _context = context;
        }

        // GET: GameLibraries
        public async Task<IActionResult> Index()
        {
            var gameLibraryContext = _context.GameLibrary.Include(g => g.GameSystems);
            return View(await gameLibraryContext.ToListAsync());
        }

        // GET: GameLibraries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameLibrary = await _context.GameLibrary
                .Include(g => g.GameSystems)
                .FirstOrDefaultAsync(m => m.GameLibraryID == id);
            if (gameLibrary == null)
            {
                return NotFound();
            }

            return View(gameLibrary);
        }

        // GET: GameLibraries/Create
        public IActionResult Create()
        {
            ViewData["GameSystemID"] = new SelectList(_context.GameSystems, "GameSystemID", "SystemName");
            return View();
        }

        // POST: GameLibraries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameLibraryID,Name,Description,GameSystemID,Rating,DiscType")] GameLibrary gameLibrary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameLibrary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameSystemID"] = new SelectList(_context.GameSystems, "GameSystemID", "SystemName", gameLibrary.GameSystemID);
            return View(gameLibrary);
        }

        // GET: GameLibraries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameLibrary = await _context.GameLibrary.FindAsync(id);
            if (gameLibrary == null)
            {
                return NotFound();
            }
            ViewData["GameSystemID"] = new SelectList(_context.GameSystems, "GameSystemID", "SystemName", gameLibrary.GameSystemID);
            return View(gameLibrary);
        }

        // POST: GameLibraries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameLibraryID,Name,Description,GameSystemID,Rating,DiscType")] GameLibrary gameLibrary)
        {
            if (id != gameLibrary.GameLibraryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameLibrary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameLibraryExists(gameLibrary.GameLibraryID))
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
            ViewData["GameSystemID"] = new SelectList(_context.GameSystems, "GameSystemID", "SystemName", gameLibrary.GameSystemID);
            return View(gameLibrary);
        }

        // GET: GameLibraries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameLibrary = await _context.GameLibrary
                .Include(g => g.GameSystems)
                .FirstOrDefaultAsync(m => m.GameLibraryID == id);
            if (gameLibrary == null)
            {
                return NotFound();
            }

            return View(gameLibrary);
        }

        // POST: GameLibraries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameLibrary = await _context.GameLibrary.FindAsync(id);
            _context.GameLibrary.Remove(gameLibrary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameLibraryExists(int id)
        {
            return _context.GameLibrary.Any(e => e.GameLibraryID == id);
        }
    }
}
