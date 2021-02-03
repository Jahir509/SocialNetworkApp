using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingApp.Models;
using DatingApp.Models.Dtos;
using DatingApp.Repository.Contracts.IAuth;
using DatingApp.Service.Contracts.IAuthService;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.Service.AuthService
{
  public class AuthService:IAuthService
  {
    private readonly IAuthRepository _repository;
    private readonly IConfiguration _config;


    public AuthService(IAuthRepository repository,IConfiguration configuration)
    {
      _repository = repository;
      _config = configuration;

    }

    public async Task<string> GenerateToken(User userDto)
    {
      var claims = new[]
      {
        new Claim(ClaimTypes.NameIdentifier, userDto.Id.ToString()),
        new Claim(ClaimTypes.Name, userDto.Username)
      };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(1),
        SigningCredentials = creds
      };

      var tokenHandler = new JwtSecurityTokenHandler();

      var token = tokenHandler.CreateToken(tokenDescriptor);

      return tokenHandler.WriteToken(token);
    }
  }
}
