using System;

namespace MunicipioApi.Models
{
    public class Entidade
    {
        public int Id { get; set; }
        public string IdAPI { get; set; }
        public string Nome { get; set; }


        public Entidade() { }

        public Entidade(Requisicao requisicao)
        {
            IdAPI = requisicao.Id;
            Nome = requisicao.Nome;
        }
    }
}
