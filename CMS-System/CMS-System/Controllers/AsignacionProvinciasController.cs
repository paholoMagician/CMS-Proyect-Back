﻿using CMS_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

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

        [HttpGet("obtenerTecnicoProvincia/{ccuser}/{ccia}")]
        public async Task<IActionResult> obtenerTecnicoProvincia([FromRoute] string ccuser, [FromRoute] string ccia )
        {

            string Sentencia = " exec ObetenerTecnicoProvincias @codUs, @codCia ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@codUs", ccuser));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@codCia", ccia));
                    adapter.Fill(dt);
                }
            }

            if (dt == null)
            {
                return NotFound("No se ha podido crear...");
            }

            return Ok(dt);

        }

        [HttpGet("eliminarTecnicoProvincia/{id}")]
        public async Task<IActionResult> eliminarTecnicoProvincia([FromRoute] int id)
        {

            string Sentencia = " delete from asignacionprovincias where id = @IDS ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@IDS", id));
                    adapter.Fill(dt);
                }
            }

            if (dt == null)
            {
                return NotFound("No se ha podido crear...");
            }

            return Ok(dt);

        }

        [HttpGet("eliminarTecnicoProvinciaPorUsuario/{codUser}/{codCia}")]
        public async Task<IActionResult> eliminarTecnicoProvinciaPorUsuario([FromRoute] string codUser, [FromRoute] string codCia )
        {

            string Sentencia = " delete from asignacionprovincias where coduser = @ccuser and codcia = @ccia ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@ccuser", codUser));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@ccia", codCia));
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
