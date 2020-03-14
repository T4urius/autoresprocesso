using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SW.ProcessoSeletivo.Repository.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW.ProcessoSeletivo.Repository.Data
{
    public class SWAutoresDataContext : DbContext
    {
        private readonly IConfiguration _config;
        public SWAutoresDataContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutoresMap());
        }
    }
}
