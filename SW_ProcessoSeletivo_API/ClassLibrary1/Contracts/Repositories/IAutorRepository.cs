using SW.ProcessoSeletivo.Domain.DTOs;
using SW.ProcessoSeletivo.Domain.Entities;

namespace SW.ProcessoSeletivo.Domain.Contracts.Repositories
{
    public interface IAutorRepository
    {
        void DeleteAutor(int idAutor);
        void InserirAutor(AutoresRequest request);
    }
}