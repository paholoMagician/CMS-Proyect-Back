using CMS_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS_System.Controllers
{
    [Route("api/asignacionProvincias")]
    [ApiController]
    public class AsignacionProvinciasController : ControllerBase
    {

        private readonly CMSSoftwarecontrolContext _context;

        public AsignacionProvinciasController(CMSSoftwarecontrolContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("saveAsignacion")]
        public async Task<IActionResult> saveAsignacion([FromBody] Asignacionprovincias model)
        {
            if (ModelState.IsValid)
            {
                _context.Asignacionprovincias.Add(model);
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
