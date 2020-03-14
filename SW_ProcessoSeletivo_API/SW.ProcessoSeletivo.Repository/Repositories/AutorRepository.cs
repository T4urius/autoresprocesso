using SW.ProcessoSeletivo.Domain.Contracts;
using SW.ProcessoSeletivo.Domain.Contracts.Repositories;
using SW.ProcessoSeletivo.Domain.DTOs;
using SW.ProcessoSeletivo.Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.ProcessoSeletivo.Repository.Repositories
{
    public class AutorRepository : IAutorRepository
    {

        public AutorRepository()
        {

        }

        public void DeleteAutor(int idAutor)
        {
            throw new NotImplementedException();
        }

        public void InserirAutor(AutoresRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
