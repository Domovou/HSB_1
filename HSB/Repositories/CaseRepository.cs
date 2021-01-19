using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSB.Models;
using HSB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HSB.Repositories
{
    public class CaseRepository : ICaseRepository
    {
         private HSBContext _context;

        public CaseRepository(HSBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Case>> GetCasesAsync(bool active)
        {
            return await _context.Cases.Where( x => x.Active == active).ToListAsync();

        }

         public async Task<Case> GetByIdAsync(Guid id)
         {
            return await _context.Cases.FirstOrDefaultAsync(x => x.ID == id);
         }

        public async Task CreateCaseAsync(Case newCase)
        {
            if (!_context.Cases.Any(x => x.FirstName == newCase.FirstName &&
                                         x.LastName == newCase.LastName &&
                                         x.Email == newCase.Email))
           
            {
                try
                {
                    newCase.ID = Guid.NewGuid();
                    await _context.Cases.AddAsync(newCase);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                throw new DbUpdateException("Case already exists", innerException:null);
            }

        }

        
        public async Task UpdateCaseAsync(Case caseToUpdate)
        {
            try
            {
                _context.Cases.Update(caseToUpdate);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;

            }
        }
        public async Task DeleteCaseAsync(Guid id)
        {
            var caseToDelete = await _context.Cases.FindAsync(id);

            try
            {
                _context.Remove(caseToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
