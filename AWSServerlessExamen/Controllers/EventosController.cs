using AWSServerlessExamen.Models;
using AWSServerlessExamen.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWSServerlessExamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private RepositoryEventos repo;

        public EventosController(RepositoryEventos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<List<CategoriaEvento>> GetCategoriasEvento()
        {
            return await this.repo.GetCategoriasEvento();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<List<Evento>> GetEventos()
        {
            return await this.repo.GetEventos();
        }

        [HttpGet]
        [Route("[action]/{idcategoria}")]
        public async Task<List<Evento>> GetEventosXCategoria(int idcategoria)
        {
            return await this.repo.GetEventosXCategoria(idcategoria);
        }

        [HttpPost]
        public async Task InsertEvento (Evento evento)
        {
            await this.repo.InsertEvento(evento);
        }

    }
}
