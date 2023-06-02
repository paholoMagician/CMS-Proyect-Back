using CMS_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS_System.Controllers
{
    [Route("api/Bodegas")]
    [ApiController]
    public class BodegasController : ControllerBase
    {

        private readonly CMSSoftwarecontrolContext _context;
        public BodegasController(CMSSoftwarecontrolContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("guardarBodegas")]
        public async Task<IActionResult> guardarBodegas([FromBody] Bodegas model)
        {

            if (_context.Bodegas.Any(c => c.Nombrebodega == model.Nombrebodega))
            {
                return BadRequest("Esta bodega ya se registró");
            }

            if (ModelState.IsValid)
            {
                _context.Bodegas.Add(model);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok(model);
                }
                else
                {
                    return BadRequest("Datos incorrectos");
                }
            }
            else
            {
                return BadRequest("ERROR");
            }
        }

        

    }
}
