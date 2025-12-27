using Mahara.Data;
using Mahara.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Mahara.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Skills
        public async Task<IActionResult> Index()
        {
            var skills = await _context.Skills.ToListAsync();
            return View(skills);
        }

        // GET: Skills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Skill skill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skill);
        }

        // GET: Skills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null) return NotFound();
            return View(skill);
        }

        // POST: Skills/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Skill skill)
        {
            if (id != skill.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(skill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skill);
        }

        // GET: Skills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null) return NotFound();
            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
