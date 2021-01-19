using HSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSB.Repositories.Interfaces
{
    public interface IDonorRepository
    {
        Task<Donor> GetByIdAsync(Guid id);
        Task<Donor> GetByPhoneNoAsync(string phoneNo);
        Task<IEnumerable<Donor>> GetDonorsAsync();
        Task CreateDonorAsync(Donor donor);
        Task UpdateDonorAsync(Donor donor);
        Task DeleteDonorAsync(Guid id);
    }
}
