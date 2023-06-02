using CMS_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CMS_System.Controllers
{
    [Route("api/Maquinaria")]
    [ApiController]
    public class MaquinariaController : ControllerBase
    {

        private readonly CMSSoftwarecontrolContext _context;

        public MaquinariaController(CMSSoftwarecontrolContext context)
        {
            _context = context;
        }

        [HttpGet("obtenerMaquinaria/{codcia}")]
        public async Task<IActionResult> obtenerMaquinaria([FromRoute] string codcia)
        {

            string Sentencia = " exec ObtenerMaquinaria @ccia ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@ccia", codcia));
                    adapter.Fill(dt);
                }
            }

            if (dt == null)
            {
                return NotFound("No se ha podido crear...");
            }

            return Ok(dt);

        }

        [HttpGet("eliminarMaquinaria/{codmaquina}")]
        public async Task<IActionResult> eliminarMaquinaria([FromRoute] string codmaquina)
        {

            string Sentencia = " exec EliminarMaquinaria @cmaquina ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@cmaquina", codmaquina));
                    adapter.Fill(dt);
                }
            }

            if (dt == null)
            {
                return NotFound("No se ha podido crear...");
            }

            return Ok(dt);

        }


        [HttpPost]
        [Route("GuardarMaquinaria")]
        public async Task<IActionResult> GuardarMaquinaria([FromBody] Maquinaria model)
        {

            if (_context.Maquinaria.Any(c => c.Codmaquina == model.Codmaquina))
            {
                return BadRequest("El RUC ya está registrado");
            }

            if (ModelState.IsValid)
            {
                _context.Maquinaria.Add(model);
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

        [HttpPut]
        [Route("EditarMaquinaria/{codmaquina}")]
        public async Task<IActionResult> EditarMaquinaria([FromRoute] string codmaquina,  [FromBody] Maquinaria model)
        {

            if (codmaquina != model.Codmaquina)
            {
                return BadRequest("No existe la maquina");
            }

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(model);

        }

    }
}
