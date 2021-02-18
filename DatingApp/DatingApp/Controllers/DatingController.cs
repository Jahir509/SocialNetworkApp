using System.Linq;
using System.Threading.Tasks;
using DatingApp.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Controllers
{
  //[Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class DatingController : ControllerBase
  {
    private readonly IDatingService _service;

    // GET
    public DatingController(IDatingService service)
    {
      _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
      var users = await _service.GetUsers();
      var data = users.Select(u=> new {u.Id,u.Username, u.Gender, u.KnownAs, u.Photos });
      return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
      var user =await _service.GetUser(id);
      return Ok(user);
    }
  }
}
