using HSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSB.Repositories.Interfaces
{
    public interface ICaseRepository
    {
        Task<Case> GetByIdAsync(Guid id);
        Task<IEnumerable<Case>> GetCasesAsync(bool active);
        Task CreateCaseAsync(Case cs);
        Task UpdateCaseAsync(Case cs);
        Task DeleteCaseAsync(Guid id);
    }
}
