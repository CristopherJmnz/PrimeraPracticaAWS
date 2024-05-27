using Microsoft.EntityFrameworkCore;
using PrimeraPracticaAWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraPracticaAWS.Data
{
    public class PelisContext: DbContext
    {
        public PelisContext(DbContextOptions<PelisContext>options)
            :base(options)
        {
            
        }

        public DbSet<Pelicula> pelis { get; set; }
    }
}
