using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingApp.Models;
using DatingApp.Models.Dtos;
using DatingApp.Repository.Contracts.IAuth;
using DatingApp.Service.Contracts.IAuthService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.Controllers.Auth
{
  [ApiController]
  [Route("api/[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly IAuthRepository _repository;
    private readonly IAuthService _service;
    private readonly IConfiguration _config;

    public AuthController(IAuthRepository repository,IConfiguration configuration, IAuthService service)
    {
      _repository = repository;
      _config = configuration;
      _service = service;
    }
    // GET
    public IActionResult Index()
    {
      return Ok();
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserDto userDto)
    {
      userDto.Username = userDto.Username.ToLower();
      if (await _repository.UserExists(userDto.Username))
      {
        return BadRequest("Username already exists");
      }

      var userToCreate = new User
      {
        Username = userDto.Username
      };

      var createdUser = await _repository.Register(userToCreate, userDto.Password);
      return StatusCode(201);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserDto userDto)
    {
      var userFromRepo = await _repository.Login(userDto.Username.ToLower(), userDto.Password);
      if (userFromRepo == null)
        return Unauthorized();

      var claims = new[]
      {
        new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
        new Claim(ClaimTypes.Name, userFromRepo.Username)
      };

      var key = new SymmetricSecurityKey(Encoding.UTF8
        .GetBytes(_config.GetSection("AppSettings:Token").Value));

      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(1),
        SigningCredentials = creds
      };

      var tokenHandler = new JwtSecurityTokenHandler();

      var token = tokenHandler.CreateToken(tokenDescriptor);

      return Ok(new
      {
        token = tokenHandler.WriteToken(token)
      });
    }
  }
}
