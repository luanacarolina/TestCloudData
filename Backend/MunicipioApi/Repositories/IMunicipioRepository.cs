using MunicipioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MunicipioApi.Repositories
{
   public interface IMunicipioRepository
    {
        Task<IEnumerable<Entidade>> Get();
        Task<Entidade> Get(int Id);
        Task<bool> Post();
        Task<Entidade> Put(Entidade entidade);
        Task<bool> Delete();
        Task Delete(int Id);
    }
}
