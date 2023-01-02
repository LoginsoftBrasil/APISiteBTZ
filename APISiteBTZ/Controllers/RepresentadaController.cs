using APISiteBTZ.Data;
using APISiteBTZ.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISiteBTZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentadaController : ControllerBase
    {
        private readonly DataContext dataContext;

        public RepresentadaController(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Representada>>> GetAll()
        {
            return Ok(await dataContext.TAB_REPRESENTADA.ToListAsync());
        }
    }
}
