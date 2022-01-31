using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MunicipioApi.Models
{
    public class MunicipioContext : DbContext 
    {
        public MunicipioContext(DbContextOptions<MunicipioContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Entidade> Entidades { get; set; }
       // public DbSet<Requisicao> Requisicaos { get; set; }
    }
}
