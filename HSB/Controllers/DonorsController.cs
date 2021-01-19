using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HSB.Models;
using HSB.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace HSB.Controllers
{
    [Authorize]
    public class DonorsController : Controller
    {
        private readonly IDonorRepository _repository;

        public DonorsController(IDonorRepository repository)
        {
            _repository = repository;
        }

        // GET: Donors
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetDonorsAsync());
        }

        // GET: Donors/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var donor = await _repository.GetByIdAsync(id);
            if (donor == null) return NotFound();
            return View(donor);
        }

        // GET: Donors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Donors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Donor donor)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateDonorAsync(donor);
                return RedirectToAction(nameof(Index));
            }
            return View(donor);
        }

        // GET: Donors/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var donor = await _repository.GetByIdAsync(id);
            if (donor == null)
            {
                return NotFound();
            }
            return View(donor);
        }

        // POST: Donors/Edit/5
        [HttpPost]
       
        public async Task<IActionResult> Edit(Guid id, [FromForm] Donor donor)
        {
            if (id != donor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await  _repository.UpdateDonorAsync(donor);
                }
                catch (DbUpdateConcurrencyException e)
                {
                    throw e;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(donor);
        }

        // GET: Donors/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var donor = await _repository.GetByIdAsync(id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }

        // POST: Donors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _repository.DeleteDonorAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
