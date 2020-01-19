using Microsoft.EntityFrameworkCore;
using net_core_bootcamp_b1_Hander.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_bootcamp_b1_Hander.Database
{
    public class BootcampHanderDbContext:DbContext
    {
        public BootcampHanderDbContext(DbContextOptions<BootcampHanderDbContext> options):base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        
    }

}
