using HSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSB.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        Task<Member>  GetByIdAsync(Guid id);
        Task<IEnumerable<Member>> GetMembersAsync(bool active);
        Task CreateMemberAsync(Member newMember);
        Task UpdateMemberAsync(Member memberToUpdate);
        Task DeleteMemberAsync(Guid id);
    }
}
