using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSB.Models;
using HSB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HSB.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private HSBContext _context;
       
        public MemberRepository(HSBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Member>> GetMembersAsync(bool active)
        {
            return await _context.Members.Where( x => x.Active == active).ToListAsync();

        }

         public async Task<Member> GetByIdAsync(Guid id)
         {
            return await _context.Members.FirstOrDefaultAsync(x => x.ID == id);
         }

        public async Task CreateMemberAsync(Member newMember)
        {
            if (!_context.Members.Any(x => x.Email == newMember.Email 
                                           && x.FirstName == newMember.FirstName
                                           && x.LastName == newMember.LastName))
           
            {
                try
                {
                    newMember.ID = Guid.NewGuid();
                    await _context.Members.AddAsync(newMember);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                throw new DbUpdateException("Members already exists", innerException:null);
            }

        }

        
        public async Task UpdateMemberAsync(Member memberToUpdate)
        {
            try
            {
                _context.Members.Update(memberToUpdate);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;

            }
        }
        public async Task DeleteMemberAsync(Guid id)
        {
            var memberToDelete = await _context.Members.FindAsync(id);

            try
            {
                _context.Remove(memberToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
