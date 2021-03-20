using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {
    private readonly IUserService _service;

    public UserController(IUserService service,IMapper mapper)
    {
      _service = service;
    }

    // GET
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
      var users = await _service.GetUsers();
      //var data = users.Select(u => new {u.Id, u.Username, u.Gender, u.KnownAs, u.Photos});
      return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
      var user = await _service.GetUser(id);
      return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id,UserDetailsDto dto)
    {
      // This line validate the user is is authorised by token match with server
      if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)) return Unauthorized();

      bool isUpdated =await _service.UpdateUser(id,dto);
      if (isUpdated) return NoContent();
      throw new Exception($"Updating user {id} failed on save");


    }
  }
}
