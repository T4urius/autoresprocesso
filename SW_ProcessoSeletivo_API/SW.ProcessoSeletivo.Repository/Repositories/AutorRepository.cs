using Microsoft.EntityFrameworkCore;
using SW.ProcessoSeletivo.Domain.Contracts;
using SW.ProcessoSeletivo.Domain.Contracts.Repositories;
using SW.ProcessoSeletivo.Domain.DTOs;
using SW.ProcessoSeletivo.Domain.Entities;
using SW.ProcessoSeletivo.Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.ProcessoSeletivo.Repository.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly SWAutoresDataContext _context;

        public AutorRepository(SWAutoresDataContext context)
        {
            _context = context;
        }

        public async Task<Autores> DeleteAutor(int idAutor)
        {
            try
            {
                var data = _context.Remove(await _context.Autores.SingleAsync(a => a.Id == idAutor));
                await _context.SaveChangesAsync();
                return data.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Autores> InserirAutor(Autores autores)
        {
            try
            {
                await _context.Autores.AddAsync(autores);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return autores;
        }

        public async Task<List<Autores>> ObterAutores()
        {
            var data = await _context.Autores.ToListAsync();

            return data;
        }
    }
}
