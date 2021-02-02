using System.Threading.Tasks;
using DatingApp.Models;
using DatingApp.Models.Dtos;
using DatingApp.Repository.Contracts.IAuth;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Controllers.Auth
{
  [ApiController]
  [Route("api/[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly IAuthRepository _repository;

    public AuthController(IAuthRepository repository)
    {
      _repository = repository;
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
  }
}
