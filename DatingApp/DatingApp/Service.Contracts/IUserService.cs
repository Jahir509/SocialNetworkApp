using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Models;

namespace DatingApp.Service.Contracts
{
  public interface IUserService
  {
    public Task<IEnumerable<User>> GetUsers();
    public Task<User> GetUser(int id);
  }
}
