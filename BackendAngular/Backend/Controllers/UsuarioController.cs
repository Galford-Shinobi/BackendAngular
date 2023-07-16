using Backend.Shared.DTO;
using Backend.Shared.UploadData;
using BackEnd.Shared.Domain.IServices;
using BackEnd.Shared.Domain.Models;
using BackEnd.Shared.DTO;
using BackEnd.Shared.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
           _usuarioService = usuarioService;
        }

        [HttpGet("ReadJson")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetReadJson([FromQuery] FiltroDTO filtro) 
        {
            try
            {
                List<MarcadoZCUDTO> List = MarketDbContextData.CargarDataAsync();

                string Searching = filtro.filtrado;
                CultureInfo culture = new CultureInfo("es-MX");
                DateTime tempDate = Convert.ToDateTime(filtro.FechaInicial, culture);
                DateTime StartDate = Convert.ToDateTime(filtro.FechaInicial, culture); ;
                DateTime EndDate = Convert.ToDateTime(filtro.FechaFinal, culture); ;

                List<MarcadoZCUDTO> Query = List
                    .Where(obj => obj.cuv == Searching || obj.NoOficio == Searching 
                    || Convert.ToDateTime(obj.FechaOfic) >= StartDate && Convert.ToDateTime(obj.FechaOfic) < EndDate).ToList();


                return Ok(new { message = "Usuario registrado con exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            try
            {
                var validateExistence = await _usuarioService.ValidateExistence(usuario);
                if (validateExistence)
                {
                    return BadRequest(new { message = "El usuario " + usuario.NombreUsuario + " ya existe!" });
                }
                usuario.Password = Encriptar.EncriptarPassword(usuario.Password);
                await _usuarioService.SaveUser(usuario);

                return Ok(new { message = "Usuario registrado con exito!" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // localhost:xxx/api/Usuario/CambiarPassword
        [Route("CambiarPassword")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<IActionResult> CambiarPassword([FromBody] CambiarPasswordDTO cambiarPassword)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;

                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);
                string passwordEncriptado = Encriptar.EncriptarPassword(cambiarPassword.passwordAnterior);
                var usuario = await _usuarioService.ValidatePassword(idUsuario, passwordEncriptado);
                if (usuario == null)
                {
                    return BadRequest(new { message = "La password es incrorrecta" });
                }
                else
                {
                    usuario.Password = Encriptar.EncriptarPassword(cambiarPassword.nuevaPassword);
                    await _usuarioService.UpdatePassword(usuario);
                    return Ok(new { message = "La password fue actualizada con exito!" });

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
