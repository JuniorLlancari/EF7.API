using AutoMapper;
using EF7.API.DTOs;
using EF7.API.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace EF7.API.Controllers
{
    [ApiController]
    [Route("api/comentarios")]
    public class ComentariosController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public ComentariosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(int peliculaId,ComentarioCreacionDTO comentarioCreacionDTO)
        {
            var comentario = mapper.Map<Comentario>(comentarioCreacionDTO);
            comentario.PeliculaId = peliculaId;
            _context.Add(comentario);
            return Ok();
            
        }

    }
}
