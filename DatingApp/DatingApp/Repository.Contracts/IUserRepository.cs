using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Repository.Contracts
{
  public interface IUserRepository
  {
    public Task<IEnumerable<User>> GetUsers();
    public Task<User> GetUser(int id);
  }
}
