using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSB.Models;
using HSB.Repositories.Interfaces;
using HSB.Services;
using Microsoft.EntityFrameworkCore;

namespace HSB.Repositories
{
    public class StoryRepository : IStoryRepository
    {
         private HSBContext _context;
         private IImageService _imageService;

        public StoryRepository(HSBContext context, IImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        public async Task<IEnumerable<Story>> GetStoriesAsync()
        {
            return await _context.Stories.ToListAsync();

        }

         public async Task<Story> GetByIdAsync(Guid id)
         {
            return await _context.Stories.FirstOrDefaultAsync(x => x.ID == id);
         }

        public async Task CreateStoryAsync(Story newStory)
        {

            try
                {
                    newStory.ID = Guid.NewGuid();
                    await _context.Stories.AddAsync(newStory);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw e;
                }
          

        }

        
        public async Task UpdateStoryAsync(Story storyToUpdate)
        {
            try
            {
                _context.Stories.Update(storyToUpdate);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;

            }
        }
        public async Task DeleteStoryAsync(Guid id)
        {
            var storyToDelete = await _context.Stories.FindAsync(id);

            try
            {
                _context.Remove(storyToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
