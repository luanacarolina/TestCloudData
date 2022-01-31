using MunicipioApi.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace MunicipioApi.Repositories
{
    public class RequisicaoRepository : IRequisicaoRepository
    {
        static readonly HttpClient client = new HttpClient();
        public readonly MunicipioContext _context;

        public RequisicaoRepository(MunicipioContext context)
        {
            _context = context;
        }
        public async Task<List<Requisicao>> ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync("http://servicodados.ibge.gov.br/api/v1/localidades/estados/MG/municipios");
            var teste = await streamTask;
            var repositories = await JsonSerializer.DeserializeAsync<List<Requisicao>>(teste);

           
                return repositories;
        }
        public async Task<bool> Post()
        {
            var entidades = await ProcessRepositories();
            foreach(var entidade in entidades)
            {
                _context.Entidades.Add(new Entidade(entidade));
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
