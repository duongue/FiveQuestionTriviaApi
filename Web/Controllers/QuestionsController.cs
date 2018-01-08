using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Domain;
using Service.Contracts;

namespace Web.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly FiveQuestionEntities _context;
        private readonly IDataService _dataService;

        public QuestionsController(FiveQuestionEntities context, IDataService dataService)
        {
            _context = context;
            _dataService = dataService;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            //var fiveQuestionEntities = _context.Questions.Include(q => q.Category).Include(q => q.Level);
            var questions = _dataService.GetAllQuestionsAsync();
            return View(await questions);
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _dataService.GetQuestionsByIdAsync(id.GetValueOrDefault());
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_dataService.GetAllCategoriesAsync().Result, "CategoryId", "Description");
            ViewData["LevelId"] = new SelectList(_dataService.GetAllLevelsAsync().Result, "LevelId", "Description");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionId,LevelId,CategoryId,Text,Answer,AdditionalInfo,Choices")] Question question)
        {
            if (ModelState.IsValid)
            {
                await _dataService.AddQuestionAsync(question);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_dataService.GetAllCategoriesAsync().Result, "CategoryId", "Description", question.CategoryId);
            ViewData["LevelId"] = new SelectList(_dataService.GetAllLevelsAsync().Result, "LevelId", "Description", question.LevelId);
            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.SingleOrDefaultAsync(m => m.QuestionId == id);
            if (question == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Description", question.CategoryId);
            ViewData["LevelId"] = new SelectList(_context.Levels, "LevelId", "Description", question.LevelId);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestionId,LevelId,CategoryId,Text,Answer,AdditionalInfo,Choices")] Question question)
        {
            if (id != question.QuestionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.QuestionId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Description", question.CategoryId);
            ViewData["LevelId"] = new SelectList(_context.Levels, "LevelId", "Description", question.LevelId);
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.Category)
                .Include(q => q.Level)
                .SingleOrDefaultAsync(m => m.QuestionId == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.Questions.SingleOrDefaultAsync(m => m.QuestionId == id);
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.QuestionId == id);
        }
    }
}
