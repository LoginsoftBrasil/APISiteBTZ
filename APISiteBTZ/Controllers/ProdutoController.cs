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
    public class ProdutoController : ControllerBase
    {
        private readonly DataContext dataContext;

        public ProdutoController(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetAll()
        {
            return Ok(await dataContext.TAB_PRODUTOS.ToListAsync());
        }
    }
}