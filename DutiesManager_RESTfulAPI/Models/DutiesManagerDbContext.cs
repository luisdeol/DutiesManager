using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutiesManager_RESTfulAPI.Models
{
    public class DutiesManagerDbContext : DbContext
    {
        public DutiesManagerDbContext(DbContextOptions<DutiesManagerDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Duty> Duties { get; set; }
    }
}
