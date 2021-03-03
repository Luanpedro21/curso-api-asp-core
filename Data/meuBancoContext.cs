using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using curso_aula1.Models;

namespace curso_aula1.Data
{
    public class meuBancoContext : DbContext
    {
        public meuBancoContext (DbContextOptions<meuBancoContext> options)
            : base(options)
        {
        }

        public DbSet<curso_aula1.Models.Cidades> Cidades { get; set; }

        public DbSet<Clientes> Clientes { get; set; }
    }
}
