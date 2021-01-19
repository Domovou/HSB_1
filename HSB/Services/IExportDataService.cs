using HSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSB.Services
{
    public interface IExportDataService<T>
    {
        byte[] CreateMembersFile(IEnumerable<Member> members);

    }
}
