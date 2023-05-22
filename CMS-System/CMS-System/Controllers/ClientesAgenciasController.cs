﻿using CMS_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CMS_System.Controllers
{
    [Route("api/ClienteAgencia")]
    [ApiController]
    public class ClientesAgenciasController : ControllerBase
    {

        private readonly CMSSoftwarecontrolContext _context;

        public ClientesAgenciasController(CMSSoftwarecontrolContext context)
        {
            _context = context;
        }

        [HttpGet("obtenerClientes/{ccia}")]
        public async Task<IActionResult> obtenerClientes([FromRoute] string ccia)
        {

            string Sentencia = " exec ObtenerCLientes @codcia";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@codcia", ccia));
                    adapter.Fill(dt);
                }
            }

            if (dt == null)
            {
                return NotFound("No se ha podido crear...");
            }

            return Ok(dt);

        }

        [HttpGet("eliminarClientes/{codcli}/{codcia}")]
        public async Task<IActionResult> eliminarClientes([FromRoute] string codcli, [FromRoute] string codcia )
        {

            string Sentencia = " delete from cliente where codcliente = @ccli and codcia = @ccia ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@ccli", codcli));
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

        [HttpPut]
        [Route("EditarCliente/{codcli}/{ccia}")]
        public async Task<IActionResult> EditarCliente([FromRoute] string codcli, [FromRoute] string ccia, [FromBody] Cliente model)
        {

            if (codcli != model.Codcliente)
            {
                return BadRequest("No existe el usuario");
            }

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(model);

        }

        [HttpPost]
        [Route("guardarCliente")]
        public async Task<IActionResult> guardarCliente([FromBody] Cliente model)
        {
            if (ModelState.IsValid)
            {
                _context.Cliente.Add(model);
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

        [HttpPost]
        [Route("guardarAgencia")]
        public async Task<IActionResult> guardarAgencia([FromBody] Agencia model)
        {
            if (ModelState.IsValid)
            {
                _context.Agencia.Add(model);
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