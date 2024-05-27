using Microsoft.EntityFrameworkCore;
using PrimeraPracticaAWS.Data;
using PrimeraPracticaAWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraPracticaAWS.Repositories
{
    public class PelisRepository
    {
        private PelisContext context;
        public PelisRepository(PelisContext context)
        {
            this.context = context;
        }

        public async Task<List<Pelicula>> GetPeliculasAsync()
        {
            return await this.context.pelis.ToListAsync();
        }

        public async Task<List<Pelicula>> GetPeliculasActorAsync(string actor)
        {
            var consulta = from datos in this.context.pelis
                           where datos.Actores.Contains(actor)
                           select datos;
            return await consulta.ToListAsync();
        }
    }
}
