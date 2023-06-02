using CMS_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CMS_System.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly CMSSoftwarecontrolContext _context;

        public UserController(CMSSoftwarecontrolContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("guardarUsuario")]
        public async Task<IActionResult> guardarUsuario([FromBody] Usuario model)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Add(model);
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



        [HttpGet("ObtenerUsuariosExec/{codcia}")]
        public async Task<IActionResult> ObtenerUsuariosExec([FromRoute] string codcia)
        {

            string Sentencia = " exec ObtenerUsuarios @ccia ";

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
                return NotFound("N pudimos traer los usuarios...");
            }

            return Ok(dt);

        }

        [HttpGet("ObtenerCuentaUsuario/{coduser}")]
        public async Task<IActionResult> ObtenerCuentaUsuario([FromRoute] string coduser)
        {

            string Sentencia = " select * from usuario where coduser = @cuser ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@cuser", coduser));
                    adapter.Fill(dt);
                }
            }

            if (dt == null)
            {
                return NotFound("No pudimos traer el usuario...");
            }

            return Ok(dt);

        }

        //[HttpGet("GetUser/{userCod}")]
        //public async Task<IActionResult> GetModulos([FromRoute] string userCod)
        //{

        //    string Sentencia = " select a.cod_user, b.* from asignModUser as a " +
        //                       " left join modulo as b on a.cod_mod = b.id " +
        //                       " where a.cod_user = @usCod order by order_mod asc ";

        //    DataTable dt = new DataTable();
        //    using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
        //        {
        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //            adapter.SelectCommand.CommandType = CommandType.Text;
        //            adapter.SelectCommand.Parameters.Add(new SqlParameter("@usCod", userCod));
        //            adapter.Fill(dt);
        //        }
        //    }

        //    if (dt == null)
        //    {
        //        return NotFound("No se encontro este WebUser...");
        //    }

        //    return Ok(dt);

        //}

        [HttpGet("GetUser/{userCod}")]
        public async Task<IActionResult> GetUser([FromRoute] string userCod)
        {
            var query = from a in _context.AsignModUser
                        join b in _context.Modulo on a.CodMod equals b.Id.ToString()
                        where a.CodUser == userCod
                        orderby a.OrderMod ascending
                        //orderby b.OrderMod ascending
                        select new { a.CodUser, b };

            var result = await query.ToListAsync();

            if (result == null)
            {
                return NotFound("No se encontró este WebUser...");
            }

            return Ok(result);
        }


        [HttpGet("eliminarUsuario/{userCod}/{codcia}")]
        public async Task<IActionResult> eliminarUsuario([FromRoute] string userCod, [FromRoute] string codcia)
        {

            string Sentencia = " delete from usuario where coduser = @usCod and codcia = @ccia; delete from asignModUser where cod_user = @usCod; ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@usCod", userCod));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@ccia", codcia));
                    adapter.Fill(dt);
                }
            }

            if (dt == null)
            {
                return NotFound("No se encontro este WebUser...");
            }

            return Ok(dt);

        }

        [HttpPut]
        [Route("EditarUsuario/{coduser}")]
        public async Task<IActionResult> EditarUsuario([FromRoute] string coduser, [FromBody] Usuario model)
        {

            if (coduser != model.Coduser)
            {
                return BadRequest("No existe el usuario");
            }

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(model);

        }

        [HttpGet("CrearCuentas/{userCod}/{ccia}/{tcuenta}")]
        public async Task<IActionResult> CrearCuentas([FromRoute] string userCod, [FromRoute] string ccia, [FromRoute] string tcuenta)
        {

            string Sentencia = " exec CrearCuenta @codUser, @codCia, @tipoCuenta ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@codUser",    userCod));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@codCia",     ccia));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@tipoCuenta", tcuenta));
                    adapter.Fill(dt);
                }
            }

            if (dt == null)
            {
                return NotFound("No se encontro este WebUser...");
            }

            return Ok(dt);

        }

    }
}
