using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HSB.Models;
using Microsoft.AspNetCore.Authorization;
using HSB.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using HSB.Services;

namespace HSB.Controllers
{
    [Authorize]
    public class StoriesController : Controller
    {
         private readonly IStoryRepository _repository;
         private readonly IImageService _imageService;

        public StoriesController(IStoryRepository repository, IImageService imageService)
        {
            _repository = repository;
            _imageService = imageService;
        }

        // GET:  Stories
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetStoriesAsync());
        }

        // GET:  Stories/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var story = await _repository.GetByIdAsync(id);
            if (story == null) return NotFound();
            return View(story);
        }

        // GET:  Stories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST:  Stories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Story story, IFormFile image)
        {
            story.ImagePath = await _imageService.UploadImage(story, image);
            ModelState.Remove("ID");
            if (ModelState.IsValid)
            {
                await _repository.CreateStoryAsync(story);
                return RedirectToAction(nameof(Index));
            }
            return View(story);
        }

        // GET:  Stories/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
          
            var story = await _repository.GetByIdAsync(id);
            if (story == null) return NotFound();
            
            return View(story);
        }

        // POST:  Stories/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, [FromForm] Story story, IFormFile newImage)
        {
            if (id != story.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await  _repository.UpdateStoryAsync(story);
                }
                catch (DbUpdateConcurrencyException e)
                {
                    throw e;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(story);
        }

        // GET:  Stories/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
           
            var story = await _repository.GetByIdAsync(id);
            if (story == null) return NotFound();
             return View(story);
        }

        // POST: Stories/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id, string imagePath)
        {
            await  _imageService.DeleteImage(imagePath);
            await _repository.DeleteStoryAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("DeleteImage")]
        public async Task<IActionResult> DeleteImage(string imagePath)
        {
            await _imageService.DeleteImage(imagePath);
            //fortsætte herfra
            return LocalRedirect(nameof(Edit));
        }
    }
}
