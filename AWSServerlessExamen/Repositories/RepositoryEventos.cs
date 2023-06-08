using AWSServerlessExamen.Data;
using AWSServerlessExamen.Models;
using Microsoft.EntityFrameworkCore;

namespace AWSServerlessExamen.Repositories
{
    public class RepositoryEventos
    {
        private EventosContext context;

        public RepositoryEventos(EventosContext context)
        {
            this.context = context;
        }

        public async Task<List<CategoriaEvento>> GetCategoriasEvento()
        {
            return await this.context.CategoriasEvento.ToListAsync();
        }

        public async Task<List<Evento>> GetEventos()
        {
            return await this.context.Eventos.ToListAsync();
        }

        public async Task<List<Evento>> GetEventosXCategoria(int idcategoria)
        {
            return await this.context.Eventos.Where(x => x.IdCategoria == idcategoria).ToListAsync();
        }

        public async Task InsertEvento(Evento evento)
        {
            evento.IdEvento = this.GetMaxIDEvento();
            this.context.Eventos.Add(evento);

            await this.context.SaveChangesAsync();
        }

        public int GetMaxIDEvento()
        {
            if (this.context.Eventos.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Eventos.Max(x => x.IdEvento) + 1;
            }
        }

    }
}
