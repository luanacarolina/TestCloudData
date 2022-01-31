using MunicipioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MunicipioApi.Repositories
{
    public interface IRequisicaoRepository
    {
        Task<List<Requisicao>> ProcessRepositories();
        Task<bool> Post();

    }
}
