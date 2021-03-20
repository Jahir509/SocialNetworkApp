using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.Models;
using DatingApp.Models.Dtos;
using DatingApp.Repository.Contracts;
using DatingApp.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Service
{
  public class UserService:IUserService
  {
    private readonly IUserRepository _repository;
    private IMapper _mapper;

    public UserService(IUserRepository repository,IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }
    public async Task<IEnumerable<UserDto>> GetUsers()
    {
      var users =await _repository.GetUsers();
      //var data = users.Select(c => new { c.Id, c.Username, c.Gender, c.City, c.Country });
      var data = _mapper.Map<IEnumerable<UserDto>>(users);
      return data;
    }

    public async Task<UserDetailsDto> GetUser(int id)
    {
      var user = await _repository.GetUser(id);
      var data = _mapper.Map<UserDetailsDto>(user);
      return data;
    }

    public async Task<bool> UpdateUser(int id,UserDetailsDto userDto)
    {
      var user = await _repository.GetUser(id);
      _mapper.Map(userDto, user);
      if (await _repository.SaveAll()) return true;
      return false;
    }
  }
}
