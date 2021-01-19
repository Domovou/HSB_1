using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HSB.Models;
using HSB.Repositories;
using Microsoft.AspNetCore.Authorization;
using HSB.Repositories.Interfaces;
using HSB.Services;
using System.Collections.Generic;

namespace HSB.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {
        private readonly IMemberRepository _repository;
        private readonly IExportDataService<Member> _exportDataService;

        public MembersController(IMemberRepository repository, IExportDataService<Member> exportDataService)
        {
            _repository = repository;
            _exportDataService = exportDataService;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetMembersAsync(true));
        }

        public async Task<IActionResult> PassiveMembers()
        {
            var members = await _repository.GetMembersAsync(false); 
            return View(members);
          
        }
        // GET: Members/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var member = await _repository.GetByIdAsync(id);
            if (member == null) return NotFound();
            return View(member);
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
        public async Task<IActionResult> Create([FromForm] Member member)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateMemberAsync(member);
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
          
            var member = await _repository.GetByIdAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, [FromForm] Member member)
        {
            if (id != member.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await  _repository.UpdateMemberAsync(member);
                }
                catch (DbUpdateConcurrencyException e)
                {
                    throw e;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
           
            var member = await _repository.GetByIdAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _repository.DeleteMemberAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> CreateCmsFile()
        {
            var _listOfMembers = await _repository.GetMembersAsync(true);

            IEnumerable<Member> listOfMembers = new List<Member>(_listOfMembers);
            byte[] mem = _exportDataService.CreateMembersFile(listOfMembers);
            

            return File(mem, "text/csv", "Export.csv");
        }
    }
}
