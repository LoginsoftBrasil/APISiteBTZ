using APISiteBTZ.Data;
using APISiteBTZ.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace APISiteBTZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DataContext dataContext;

        public ClienteController(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetAllFromUser(int codigoUsuario, bool isMaster)
        {
            if (isMaster)
            {
                return Ok(await dataContext.TAB_CLIENTES.ToListAsync());
            }
            else
            {
                return Ok(await dataContext.TAB_CLIENTES.FromSqlRaw($"SELECT COD, CLIENTES.NOME AS NOME, CONTRATO, PRAZO, FANTASIA, USADO FROM TAB_CLIENTES AS CLIENTES, TAB_CLIENTES_VENDEDOR AS CLIENTES_VENDEDOR WHERE CLIENTES.COD = CLIENTES_VENDEDOR.cod_cli AND CLIENTES_VENDEDOR.cod_vend = {codigoUsuario}").ToListAsync());
            }
        }
    }
}