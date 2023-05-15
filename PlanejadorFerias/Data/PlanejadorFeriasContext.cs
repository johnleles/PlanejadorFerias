using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlanejadorFerias.Models;

namespace PlanejadorFerias.Data
{
    public class PlanejadorFeriasContext : DbContext
    {
        public PlanejadorFeriasContext (DbContextOptions<PlanejadorFeriasContext> options)
            : base(options)
        {
        }

        public DbSet<PlanejadorFerias.Models.Colaboradores> Colaboradores { get; set; } = default!;

    }
}
