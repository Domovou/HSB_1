using HSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSB.Repositories.Interfaces
{
    public interface IStoryRepository
    {
        Task<Story> GetByIdAsync(Guid id);
        Task<IEnumerable<Story>> GetStoriesAsync();
        Task CreateStoryAsync(Story story);
        Task UpdateStoryAsync(Story story);
        Task DeleteStoryAsync(Guid id);
    }
}
