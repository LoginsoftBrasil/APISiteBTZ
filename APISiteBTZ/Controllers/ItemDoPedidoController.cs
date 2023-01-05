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
    public class ItemDoPedidoController : ControllerBase
    {
        private readonly DataContext dataContext;

        public ItemDoPedidoController(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<ItemDoPedido>>> GetFromPedido(int codigoPedido, int codigoUsuario, bool isMaster)
        {
            if (isMaster)
            {
                return Ok(await dataContext.Tab_PED_ITENS.Where(x => x.cd_ped == codigoPedido).ToListAsync());
            }
            else
            {
                return Ok(await dataContext.Tab_PED_ITENS.FromSqlRaw($"SELECT ID, Tab_PED_ITENS.CD_PED AS CD_PED, CD_PROD, DESCR, QTDE, VALOR_UNIT, Tab_PED_ITENS.VALOR_TOTAL AS VALOR_TOTAL FROM Tab_PED_ITENS, Tab_PEDIDOS WHERE Tab_PEDIDOS.CD_VEND = {codigoUsuario} AND Tab_PED_ITENS.CD_PED = Tab_PEDIDOS.CD_PED").ToListAsync());
            }
        }
    }
}