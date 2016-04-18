using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace WarHammer.Models
{   
    public class WarHammerContext : DbContext
    {
        public virtual DbSet<Army> Armies { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        protected override void OnConfiguring (DbContextOptionsBuilder options)
        {
                options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WarHammer;integrated security = True");
        }
     }
}