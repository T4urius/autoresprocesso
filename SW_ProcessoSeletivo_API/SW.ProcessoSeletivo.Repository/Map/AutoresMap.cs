using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SW.ProcessoSeletivo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW.ProcessoSeletivo.Repository.Map
{
    public class AutoresMap : IEntityTypeConfiguration<Autores>
    {
        public void Configure(EntityTypeBuilder<Autores> builder)
        {
            builder.ToTable("autores");
            builder.HasKey(c => c.Id);

            builder.Property(col => col.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(col => col.Nome)
                .HasColumnName("nome")
                .IsRequired();
        }
    }
}
