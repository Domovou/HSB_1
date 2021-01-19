using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HSB.Areas.Identity.Pages.Account;
using HSB.Data;
using Microsoft.AspNetCore.Mvc;
using HSB.Models;
using HSB.Repositories.Interfaces;
using HSB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace HSB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IDonorRepository _donorRepository;
        private readonly ICaseRepository _caseRepository;
        private readonly IStoryRepository _storyRepository;
        private readonly WelcomeMail _welcomeMail;
        

        public HomeController(IMemberRepository memberRepository,
            IDonorRepository donorRepository,
            ICaseRepository caseRepository,
            IStoryRepository storyRepository,
            WelcomeMail welcomeMail)
        {
            _memberRepository = memberRepository;
            _donorRepository = donorRepository;
            _caseRepository = caseRepository;
            _storyRepository = storyRepository;
            _welcomeMail = welcomeMail;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _storyRepository.GetStoriesAsync());
        }


        public IActionResult AddMember()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> AddMember([FromForm] Member member)
        {
            if (ModelState.IsValid)
            {
                await _memberRepository.CreateMemberAsync(member);
                await _welcomeMail.SendWelcomeEmail(member.Email, member.FirstName);
                return View("MemberAdded");
            }
            return View(member);
        }

        public IActionResult AddDonor()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> AddDonor([FromForm] Donor donor)
        {
            if (ModelState.IsValid)
            {
                await _donorRepository.CreateDonorAsync(donor);
                return View("DonorAdded");
            }
            return View(donor);
        }

        public IActionResult AddCase()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> AddCase([FromForm] Case myCase)
        {
            if (ModelState.IsValid)
            {
                await _caseRepository.CreateCaseAsync(myCase);
                return View("CaseAdded");
            }
            return View(myCase);
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel(HttpContext.Response.StatusCode)
            {
              RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
