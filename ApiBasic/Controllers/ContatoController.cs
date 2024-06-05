using ApiBasic.Context;
using ApiBasic.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBasic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }


        [HttpPost ]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return Ok(contato);
        }

        [HttpGet("{id}") ]
        public IActionResult ObterPorID(int id)
        {
            var contato = _context.Contatos.Find(id);
            
            //validacao para ver se o contato existe
            if (contato == null)
            {
                return NotFound();
            }

            return Ok(contato);
        }

    }
}
