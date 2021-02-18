using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.Models.Dtos;
using DatingApp.Repository;
using DatingApp.Repository.Contracts;
using DatingApp.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {
    private readonly IUserService _service;
    private readonly IMapper _mapper;

    public UserController(IUserService service,IMapper mapper)
    {
      _service = service;
      _mapper = mapper;
    }

    // GET
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
      var users = await _service.GetUsers();
      //var data = users.Select(u => new {u.Id, u.Username, u.Gender, u.KnownAs, u.Photos});
      var data = _mapper.Map<IEnumerable<UserDto>>(users);
      return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
      var user = await _service.GetUser(id);

      var data = _mapper.Map< UserDetailsDto > (user);

      return Ok(data);
    }
  }
}
