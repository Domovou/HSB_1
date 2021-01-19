using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HSB.Models;
using Microsoft.AspNetCore.Authorization;
using HSB.Repositories.Interfaces;

namespace HSB.Controllers
{
    [Authorize]
    public class CasesController : Controller
    {
        private readonly ICaseRepository _repository;

        public CasesController(ICaseRepository repository)
        {
            _repository = repository;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetCasesAsync(true));
        }

        public async Task<IActionResult> PassiveCases()
        {
            var cases = await _repository.GetCasesAsync(false); 
            return View(cases);
          
        }
        // GET: Members/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var myCase = await _repository.GetByIdAsync(id);
            if (myCase == null) return NotFound();
            return View(myCase);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Case myCase)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateCaseAsync(myCase);
                return RedirectToAction(nameof(Index));
            }
            return View(myCase);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
          
            var myCase = await _repository.GetByIdAsync(id);
            if (myCase == null)
            {
                return NotFound();
            }
            return View(myCase);
        }

        // POST: Members/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, [FromForm] Case myCase)
        {
            if (id != myCase.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await  _repository.UpdateCaseAsync(myCase);
                }
                catch (DbUpdateConcurrencyException e)
                {
                    throw e;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(myCase);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
           
            var myCase = await _repository.GetByIdAsync(id);
            if (myCase == null)
            {
                return NotFound();
            }

            return View(myCase);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _repository.DeleteCaseAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
