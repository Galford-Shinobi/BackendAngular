using Backend.Shared.DTO;
using BackEnd.Shared.Domain.IServices;
using BackEnd.Shared.Domain.Models;
using BackEnd.Shared.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _config;

        public LoginController(ILoginService loginService, IConfiguration config)
        {
            _loginService = loginService;
            _config = config;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            try
            {
                usuario.Password = Encriptar.EncriptarPassword(usuario.Password);
                var user = await _loginService.ValidateUser(usuario);
                if (user == null)
                {
                    return BadRequest(new { message = "Usuario o contraseña invalidos" });
                }
                TokenDTO tokenString = JwtConfigurator.GetToken(user, _config);
                return Ok(new { token = tokenString.Token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
