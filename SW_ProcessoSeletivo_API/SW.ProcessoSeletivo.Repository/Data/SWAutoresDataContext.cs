using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SW.ProcessoSeletivo.Domain.Entities;
using SW.ProcessoSeletivo.Repository.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW.ProcessoSeletivo.Repository.Data
{
    public class SWAutoresDataContext : DbContext
    {
        public SWAutoresDataContext(DbContextOptions<SWAutoresDataContext> options): base(options)
        {

        }

        public virtual DbSet<Autores> Autores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutoresMap());
        }
    }
}
