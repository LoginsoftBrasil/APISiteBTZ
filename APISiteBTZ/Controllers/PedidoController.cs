using APISiteBTZ.Data;
using APISiteBTZ.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISiteBTZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly DataContext dataContext;

        public PedidoController(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> GetAll(int codigoUsuario, bool isMaster)
        {
            if (isMaster)
            {
                return Ok(await dataContext.Tab_PEDIDOS.ToListAsync());
            }
            else
            {
                return Ok(await dataContext.Tab_PEDIDOS.FromSqlRaw($"SELECT CD_PED, DATA_REG, CD_CL, STATUS_PED, CD_VEND, VALOR_TOTAL, CD_REPR, DATA_PRAZO, COMISSAO_VENDEDOR, OBS_GERAIS, CD_COMPRADOR, ETIQUETA, TELEFONE, NOME, FANTASIA  FROM Tab_PEDIDOS INNER JOIN TAB_CLIENTES ON Tab_PEDIDOS.CD_CL = TAB_CLIENTES.COD WHERE CD_VEND = { codigoUsuario }").ToListAsync());
            }
        }
    }
}