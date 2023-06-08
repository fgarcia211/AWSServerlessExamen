using AWSServerlessExamen.Models;
using Microsoft.EntityFrameworkCore;

namespace AWSServerlessExamen.Data
{
    public class EventosContext : DbContext
    {
        public EventosContext(DbContextOptions<EventosContext> options): base(options) { }

        public DbSet<CategoriaEvento> CategoriasEvento { get; set; }

        public DbSet<Evento> Eventos { get; set; }
    }
}
