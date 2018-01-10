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
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class EncouragementsController : Controller
    {
        private readonly IDataService _dataService;

        public EncouragementsController(IDataService dataService)
        {
            _dataService = dataService;
        }

        // GET: Encouragements
        public async Task<IActionResult> Index()
        {
            return View(await _dataService.GetAllEncouragementAsync());
        }

        // GET: Encouragements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encouragement = await _dataService.GetEncourgementByIdAsync(id.GetValueOrDefault());
            if (encouragement == null)
            {
                return NotFound();
            }

            return View(encouragement);
        }

        // GET: Encouragements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Encouragements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Text,SaysOnCorrectAnswer")] Encouragement encouragement)
        {
            if (ModelState.IsValid)
            {
                await _dataService.AddEncouragementAsync(encouragement);
                return RedirectToAction(nameof(Index));
            }
            return View(encouragement);
        }

        // GET: Encouragements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encouragement = await _dataService.GetEncourgementByIdAsync(id.GetValueOrDefault());
            if (encouragement == null)
            {
                return NotFound();
            }
            return View(encouragement);
        }

        // POST: Encouragements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Text,SaysOnCorrectAnswer")] Encouragement encouragement)
        {
            if (id != encouragement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _dataService.UpdateEncouragementAsync(encouragement);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncouragementExists(encouragement.Id))
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
            return View(encouragement);
        }

        // GET: Encouragements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encouragement = await _dataService.GetEncourgementByIdAsync(id.GetValueOrDefault());
            if (encouragement == null)
            {
                return NotFound();
            }

            return View(encouragement);
        }

        // POST: Encouragements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var encouragement = await _dataService.GetEncourgementByIdAsync(id);
            await _dataService.DeleteEncouragementAsync(encouragement);
            return RedirectToAction(nameof(Index));
        }

        private bool EncouragementExists(int id)
        {
            return _dataService.GetEncourgementByIdAsync(id) != null? true:false;
        }
    }
}
