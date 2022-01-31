using Microsoft.EntityFrameworkCore;
using MunicipioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace MunicipioApi.Repositories
{
    public class MunicipioRepository : IMunicipioRepository
    {
        
        public readonly MunicipioContext _context;
        static readonly HttpClient client = new HttpClient();


        public MunicipioRepository(MunicipioContext context)
        {
            _context = context;
        }

   
        public async Task<IEnumerable<Entidade>> Get()
        {
           
            return await  _context.Entidades.ToListAsync();
        }

        public async Task<Entidade> Get(int Id)
        {
            return await _context.Entidades.FindAsync(Id);
        }

        public async Task<bool> Post()
        {

            if (await _context.Entidades.AnyAsync()) return true;

            var entidades = await ProcessRepositories();

            foreach (var entidade in entidades)
            {
                _context.Entidades.Add(new Entidade(entidade));
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Entidade> Put(Entidade entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entidade;
        }
        public async Task Delete(int Id)
        {
            var entidadeDelete = await _context.Entidades.FindAsync(Id);
            _context.Entidades.Remove(entidadeDelete);
            await _context.SaveChangesAsync();
        }

        private async Task<List<Requisicao>> ProcessRepositories()
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

        public async Task<bool> Delete()
        {

            var all = from e in _context.Entidades select e;
            _context.Entidades.RemoveRange(all);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            } catch
            {
                return false;
            }
        }

      
    }
}
