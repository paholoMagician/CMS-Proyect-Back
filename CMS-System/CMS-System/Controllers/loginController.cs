﻿using CMS_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS_System.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class loginController : ControllerBase
    {

        private readonly CMSSoftwarecontrolContext _context;

        public loginController(CMSSoftwarecontrolContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Usuario userInfo)
        {
            var result = await _context.Usuario.FirstOrDefaultAsync(x => x.Email == userInfo.Email && x.Contrasenia == userInfo.Contrasenia);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                //ModelState.AddModelError(string.Empty, "Usuario o contraseña invalido");
                return BadRequest("Datos incorrectos");
            }
        }

    }
}
