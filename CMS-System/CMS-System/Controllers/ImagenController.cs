using CMS_System.fileModel;
using CMS_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CMS_System.Controllers
{
    [Route("api/Imagen")]
    [ApiController]
    public class ImagenController : ControllerBase
    {

        private readonly CMSSoftwarecontrolContext _context;

        public ImagenController(CMSSoftwarecontrolContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("crearCarpeta/{nombre}")]
        public async Task<IActionResult> crearCarpeta([FromForm] IMGmodelClass request, [FromRoute] string nombre)
        {
            string fileModelpath = Path.Combine(Directory.GetCurrentDirectory(), "fileModel");
            string assetsPath = Path.Combine(fileModelpath, "Assets");
            string imagePath = Path.Combine(assetsPath, nombre);

            try
            {

                if (!Directory.Exists(assetsPath))
                    Directory.CreateDirectory(assetsPath);

                if (!Directory.Exists(imagePath))
                {
                    Directory.CreateDirectory(imagePath);
                    // Obtén la ruta completa del archivo en lugar de solo la carpeta
                    string filePath = Path.Combine(imagePath, request.Archivo.FileName);
                    using (FileStream newFile = System.IO.File.Create(filePath))
                    {
                        await request.Archivo.CopyToAsync(newFile);
                        await newFile.FlushAsync();
                    }
                
                }

                return Ok("La carpeta se ha creado");
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }

        [HttpPost]
        [Route("saveImagen")]
        public async Task<IActionResult> saveImagen([FromBody] Imgfile model)
        {
            if (ModelState.IsValid)
            {
                _context.Imgfile.Add(model);
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


        [HttpGet("obtenerImagen/{cUser}/{tp}")]
        public async Task<IActionResult> obtenerImagen([FromRoute] string cUser, [FromRoute] string tp)
        {

            string Sentencia = " select * from imgfile where codentidad = @cBinding and tipo = @tipo ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@cBinding", cUser));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@tipo", tp));
                    adapter.Fill(dt);
                }
            }

            if (dt == null)
            {
                return NotFound("No se ha podido crear...");
            }

            return Ok(dt);

        }


    }
}
