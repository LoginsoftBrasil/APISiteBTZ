using APISiteBTZ.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISiteBTZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext dataContext;

        public UsuarioController(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get(string nomeUsuario, string senhaUsuario)
        {
            var a = await dataContext.TAB_USUARIOS.Where(x => x.nome == nomeUsuario.ToUpper() && x.senha == senhaUsuario.ToUpper()).AnyAsync();

            if (!a)
            {
                return BadRequest("Usuário não existe");
            }

            return Ok("Usuário existe");
        }
    }
}