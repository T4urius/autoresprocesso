using SW.ProcessoSeletivo.Domain.DTOs;
using SW.ProcessoSeletivo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW.ProcessoSeletivo.Domain.Contracts.Repositories
{
    public interface IAutorRepository
    {
        Task<Autores> DeleteAutor(int idAutor);
        Task<List<Autores>> ObterAutores();
        Task<Autores> InserirAutor(Autores autores);
    }
}