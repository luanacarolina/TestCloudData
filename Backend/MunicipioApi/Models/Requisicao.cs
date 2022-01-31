using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MunicipioApi.Models
{
    public class Requisicao
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
        
    }
}
