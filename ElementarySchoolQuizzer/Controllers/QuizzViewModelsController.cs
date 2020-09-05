using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElementarySchoolQuizzer.Data;
using ElementarySchoolQuizzer.Models;

namespace ElementarySchoolQuizzer.Controllers
{
    public class QuizzViewModelsController : Controller
    {
        private readonly DataContext _context;

        // GET: QuizzViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Quizzes.ToListAsync());
        }

        // GET: QuizzViewModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizzViewModel = await _context.QuizzViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quizzViewModel == null)
            {
                return NotFound();
            }

            return View(quizzViewModel);
        }

        // GET: QuizzViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuizzViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Owner,Start,End,Published")] QuizzViewModel quizzViewModel)
        {
            if (ModelState.IsValid)
            {
                quizzViewModel.Id = Guid.NewGuid();
                _context.Add(quizzViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quizzViewModel);
        }

        // GET: QuizzViewModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizzViewModel = await _context.QuizzViewModel.FindAsync(id);
            if (quizzViewModel == null)
            {
                return NotFound();
            }
            return View(quizzViewModel);
        }

        // POST: QuizzViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Owner,Start,End,Published")] QuizzViewModel quizzViewModel)
        {
            if (id != quizzViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quizzViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizzViewModelExists(quizzViewModel.Id))
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
            return View(quizzViewModel);
        }

        // GET: QuizzViewModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizzViewModel = await _context.QuizzViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quizzViewModel == null)
            {
                return NotFound();
            }

            return View(quizzViewModel);
        }

        // POST: QuizzViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var quizzViewModel = await _context.QuizzViewModel.FindAsync(id);
            _context.QuizzViewModel.Remove(quizzViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuizzViewModelExists(Guid id)
        {
            return _context.QuizzViewModel.Any(e => e.Id == id);
        }
    }
}
