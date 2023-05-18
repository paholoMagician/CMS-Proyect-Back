using CMS_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CMS_System.Controllers
{
    [Route("api/modulos")]
    [ApiController]
    public class ModuloController : ControllerBase
    {

        private readonly CMSSoftwarecontrolContext _context;

        public ModuloController(CMSSoftwarecontrolContext context)
        {
            _context = context;
        }

        [HttpGet("GetModulos/{userCod}")]
        public async Task<IActionResult> GetModulos([FromRoute] string userCod)
        {

            string Sentencia = " select a.cod_user, b.* from asignModUser as a " +
                               " left join modulo as b on a.cod_mod = b.id " +
                               " where a.cod_user = @usCod order by order_mod asc ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@usCod", userCod));
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
