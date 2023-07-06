using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UtilitiesProject.Data
{
    public class UtilityContext : DbContext
    {
        public UtilityContext(DbContextOptions<UtilityContext> options)
    : base(options)
        {
        }
        public DbSet<UtilitiesProject.Models.Utility>? Utilities { get; set; }

    }
}
