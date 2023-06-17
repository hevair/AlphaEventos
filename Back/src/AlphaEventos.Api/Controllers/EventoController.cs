using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AlphaEventos.Domain;
using AlphaEventos.Persistence.Context;

namespace AlphaEventos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        private readonly AlphaEventosContext _context;

        public EventoController(AlphaEventosContext context)
        {
            _context = context;
        }

        IEnumerable<Evento> _eventos = new Evento[]
        {
                // new Evento {
                //     EventoId = 1,
                //     Tema = "Angular 11 e .net 5",
                //     Local = "São Paulo",
                //     Lote = "primeiro lote",
                //     QtdPessoa = 250,
                //     DataEvento = DateTime.Now.AddDays(2).ToString()
                // },
                // new Evento {
                //     EventoId = 2,
                //     Tema = "Angular e as melhorias",
                //     Local = "São Paulo",
                //     Lote = "2 lote",
                //     QtdPessoa = 300,
                //     DataEvento = DateTime.Now.AddDays(2).ToString()
                // }
        };

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        
        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _context.Eventos.Where(e => e.Id == id);
        }
    }
}

