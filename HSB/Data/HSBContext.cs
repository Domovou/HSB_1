using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HSB.Models;

namespace HSB.Models
{
    public class HSBContext : DbContext
    {
        public HSBContext (DbContextOptions<HSBContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<Case> Cases { get; set; }

        public DbSet<Story> Stories { get; set; }

    }
}
