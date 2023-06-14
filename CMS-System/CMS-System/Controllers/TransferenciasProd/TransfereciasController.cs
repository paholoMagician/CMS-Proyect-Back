using CMS_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CMS_System.Controllers.TransferenciasProd
{
    [Route("api/Transferencias")]
    [ApiController]
    public class TransfereciasController : ControllerBase
    {

        readonly CMSSoftwarecontrolContext _context;

        public TransfereciasController(CMSSoftwarecontrolContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("ProcesoTransdferenciaBod")]
        public async Task<IActionResult> ProcesoTransdferenciaBod([FromBody] Transferencia model )
        {

            string Sentencia = " exec ProcesoTransdferenciaBod @codprod, @state, @cuser, @boden, @bodsal, @ccia ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@codprod",   model.Codprod));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@state",     model.State));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@cuser",     model.Cuser));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@boden",     model.Boden));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@bodsal",    model.Bodsal));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@ccia",      model.Ccia));
                    adapter.Fill(dt);
                }
            }

            if (dt == null)
            {
                return NotFound("No se ha podido crear...");
            }

            return Ok(dt);

        }

        [HttpGet]
        [Route("repoOrdenTransferProd/{ccia}/{ccab}")]
        public async Task<IActionResult> repoOrdenTransferProd([FromRoute] string ccia, [FromRoute] string ccab)
        {

            string Sentencia = " exec RepoOrdenTransferProd @codcia, @codcab ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@codcia", ccia));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@codcab", ccab));
                    adapter.Fill(dt);
                }
            }

            if (dt == null)
            {
                return NotFound("No se ha podido crear...");
            }

            return Ok(dt);

        }
        
        [HttpGet]
        [Route("invmov")]
        public async Task<IActionResult> invmoc()
        {

            string Sentencia = " select * from invmov ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;

                    adapter.Fill(dt);
                }
            }

            if (dt == null)
            {
                return NotFound("No se ha podido crear...");
            }

            return Ok(dt);

        }
        
        [HttpGet]
        [Route("obtenerDetalleTrans/{codcabe}")]
        public async Task<IActionResult> obtenerDetalleTrans([FromRoute] string codcabe )
        {

            string Sentencia = " select mq.nombremaquina, mq.nserie, mq.marca, mq.modelo, edet.* from entytrandet as edet " +
                               " left join maquinaria as mq on mq.codmaquina = edet.codprod " +
                               " where edet.codtran = @codcab ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@codcab", codcabe));
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
        [Route("guardarDetalleTransaciion")]
        public async Task<IActionResult> guardarDetalleTransaciion([FromBody] Entytrandet model)
        {

            //if (_context.Entytrandet.Any(c => c.Codmaquina == model.Codmaquina))
            //{
            //    return BadRequest("Este producto ya existe en el detalle");
            //}

            if (ModelState.IsValid)
            {
                _context.Entytrandet.Add(model);
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
