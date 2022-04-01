﻿using _2RPNET_API.Interfaces;
using _2RPNET_API.Repositories;
using _2RPNET_API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace _2RPNET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IUserNameRepository _userRepository;

        public LoginController(UserNameRepository ctx)
        {
            _userRepository = ctx;
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel UserLogin)
        {
            try
            {
                UserName queryUser = _userRepository.Login(UserLogin.email, UserLogin.password);

                if (queryUser == null)
                {
                    return Unauthorized(new { msg = "Email ou senha inválidos!" });
                }

                if (queryUser.Passwd == null)
                {
                    return Unauthorized(new { msg = "Realize o login com o google!" });
                }

                var tokenClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, queryUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, queryUser.IdUser.ToString()),
                    new Claim(ClaimTypes.Role, queryUser.IdUserType.ToString()),
                    new Claim("role", queryUser.IdUserType.ToString()),


                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("2rp-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var myToken = new JwtSecurityToken(
                        issuer: "2rp.webAPI",
                        audience: "2rp.webAPI",
                        claims: tokenClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(myToken)
                });
            }
            catch (Exception error)
            {
                return BadRequest(error);
                throw;
            }
        }
    }
}

