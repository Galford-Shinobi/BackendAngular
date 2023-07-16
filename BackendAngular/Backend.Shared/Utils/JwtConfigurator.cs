﻿using Backend.Shared.DTO;
using BackEnd.Shared.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackEnd.Shared.Utils
{
    public class JwtConfigurator
    {
        public static TokenDTO GetToken(Usuario userInfo, IConfiguration config)
        {
            string SecretKey = config["Jwt:SecretKey"];
            string Issuer = config["Jwt:Issuer"];
            string Audience = config["Jwt:Audience"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
           {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.NombreUsuario),
                new Claim("idUsuario", userInfo.Id.ToString())
            };
            var expiration = DateTime.UtcNow.AddMinutes(60);
            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims,
                 expires: expiration,
                signingCredentials: credentials
                );
            return new TokenDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

        public static int GetTokenIdUsuario(ClaimsIdentity identity)
        {
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                foreach (var claim in claims)
                {
                    if (claim.Type == "idUsuario")
                    {
                        return int.Parse(claim.Value);
                    }
                }
            }
            return 0;
        }
    }
}
