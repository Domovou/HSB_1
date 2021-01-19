using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSB.Models;
using HSB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HSB.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private HSBContext _context;

        public DonorRepository(HSBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Donor>> GetDonorsAsync()
        {
            return await _context.Donors.ToListAsync();
        }

        public async Task<Donor> GetByIdAsync(Guid id)
        {
            return await _context.Donors.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<Donor> GetByPhoneNoAsync(string phoneNo)
        {
            return await _context.Donors.FirstOrDefaultAsync(x => x.PhoneNo == phoneNo);
        }


        public async Task CreateDonorAsync(Donor donor)
        {
            if (!_context.Donors.Any(x => x.PhoneNo == donor.PhoneNo
                                           && x.FirstName == donor.FirstName
                                           && x.LastName == donor.LastName))
           
            {
                try
                {
                    donor.ID = Guid.NewGuid();
                    await _context.Donors.AddAsync(donor);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                throw new DbUpdateException("Donor already exists", innerException:null);
            }

        }

       
       
        public async Task UpdateDonorAsync(Donor donor)
        {
            try
            {
                _context.Donors.Update(donor);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;

            }
        }

        public async Task DeleteDonorAsync(Guid id)
        {
            var donorToDelete = await _context.Donors.FindAsync(id);

            try
            {
                _context.Remove(donorToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
