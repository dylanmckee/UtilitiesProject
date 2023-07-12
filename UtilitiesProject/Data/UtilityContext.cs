using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UtilitiesProject.Models;

namespace UtilitiesProject.Data
{
    public class UtilityContext : DbContext
    {
        public UtilityContext(DbContextOptions options ): base(options)
        {
        }
        public DbSet<Utility> Utilities { get; set; }

    }
}
