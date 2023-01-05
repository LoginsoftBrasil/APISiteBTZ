using APISiteBTZ.Data;
using APISiteBTZ.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISiteBTZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompradorController : ControllerBase
    {
        private readonly DataContext dataContext;

        public CompradorController(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Comprador>>> GetAllFromCliente(int codCliente)
        {
            return Ok(await dataContext.TAB_CONTATOS.FromSqlRaw($"SELECT COD, NOME, TELEFONE, COD_CLIENTE FROM TAB_CONTATOS WHERE COD_CLIENTE = {codCliente}").ToListAsync());
        }
    }
}