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

        [HttpGet("ObterNome")]
        public IActionResult ObterPorNome(string nome) 
        {
            //usado o linq, vai conter o nome onde vou estar passando via paramentro ai em cima. 
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));
            return Ok(contatos);
        }  


        [HttpPut("{id}")]
        //  o " Atualizar(int id, Contato contato)" o contato vai ser um json dos contatos q vao ser atualizados.
        public IActionResult Atualizar(int id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if (contatoBanco == null)
            {
                return NotFound();
            }
            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);

        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id) 
        {
            var contatoBanco = _context.Contatos.Find(id);
            if (contatoBanco == null)
                return NotFound();

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();

            return NoContent();
            
        }

    }
}
