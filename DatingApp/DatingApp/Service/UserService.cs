using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Models;
using DatingApp.Repository.Contracts;
using DatingApp.Service.Contracts;

namespace DatingApp.Service
{
  public class UserService:IUserService
  {
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
      _repository = repository;
    }
    public async Task<IEnumerable<User>> GetUsers()
    {
      var users =await _repository.GetUsers();
      //var data = users.Select(c => new { c.Id, c.Username, c.Gender, c.City, c.Country });
      return users;
    }

    public async Task<User> GetUser(int id)
    {
      return await _repository.GetUser(id);
    }
  }
}
