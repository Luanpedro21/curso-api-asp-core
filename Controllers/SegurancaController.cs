using curso_aula1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curso_aula1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegurancaController : ControllerBase
    {

        private readonly IConfiguration _config;

        public SegurancaController(IConfiguration config)
        {
            _config = config;
        }


        [HttpPost]
        public IActionResult Login([FromBody]UsuariosSistema usuario)
        {
            bool achou = ValidarUsuario(usuario);
            if(achou)
            {
                var tokenString = GerarTokenJwt();
                return Ok(new { token = tokenString });
            }
            else
            {
                return Unauthorized();
            }

        }

        private bool ValidarUsuario(UsuariosSistema usuario)
        {

            if (usuario.username == "luan" && usuario.password == "123")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private string GerarTokenJwt()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(60);
            var securityKey = new SymmetricSecurityKey
                              (Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials
                              (securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer,
                                             audience: audience,
                                             expires: DateTime.Now.AddMinutes(120),
                                             signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }


    }
}
