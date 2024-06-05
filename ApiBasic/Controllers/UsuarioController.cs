using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBasic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("ObtDataeHoraAtual")]
        public IActionResult ObtDataHora()
        {
            var obj = new 
            { 
                Data = DateTime.Now.ToLongDateString(),
                Hora = DateTime.Now.ToLongTimeString()
            };
            return Ok(obj);
        }


        [HttpGet("Apresentar/{nome}")]
        public IActionResult apresentar(string nome)
        {
            var mensagem = $"ola {nome}, bem vindo";
              return Ok(mensagem);
        }
       
        
    }
}
