using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASP_Project.Model
{
    public class ApplicationDbContext : DbContext
    {
        // constructor short form = ctor
        // Parameter is needed for dependency injection 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //entry for dbs 
        public DbSet<Book> Book { get; set; }
    }
}
