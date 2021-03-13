using System;
using GeothermalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GeothermalAPI.Database
{
    public class GeothermalContext : DbContext
    {
        public GeothermalContext(DbContextOptions<GeothermalContext> options) : base(options)
        {
        }

        public DbSet<Installer> Installers { get; set; }
    }
}
