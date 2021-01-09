using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace razorqqq.Model
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option)
        {

        }
        public DbSet<Book> Book { get; set; }
        public DbSet<Copy> Copy { get; set; }
    }
}
