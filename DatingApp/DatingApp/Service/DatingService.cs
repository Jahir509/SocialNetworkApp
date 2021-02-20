using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Models;
using DatingApp.Repository.Contracts;
using DatingApp.Service.Contracts;

namespace DatingApp.Service
{
  public class DatingService:IDatingService
  {
    private readonly IDatingRepository _repository;

    public DatingService(IDatingRepository repository)
    {
      _repository = repository;
    }
    public void Add<T>(T entity) where T : class
    {
      throw new System.NotImplementedException();
    }

    public void Delete<T>(T entity) where T : class
    {
      throw new System.NotImplementedException();
    }

    public Task<bool> SaveAll()
    {
      throw new System.NotImplementedException();
    }

    public Task<User> GetUser(int id)
    {
      var user = _repository.GetUser(id);
      return user;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
      var users =await _repository.GetUsers();
      //var data = users.Select(u => new {u.Id, u.Username, u.Gender, u.KnownAs, u.Photos});
      return users;
    }
  }
}
