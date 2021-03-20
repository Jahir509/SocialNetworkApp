using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Models;
using DatingApp.Models.Dtos;

namespace DatingApp.Service.Contracts
{
  public interface IUserService
  {
    public Task<IEnumerable<UserDto>> GetUsers();
    public Task<UserDetailsDto> GetUser(int id);
    public Task<bool> UpdateUser(int id,UserDetailsDto dto);
  }
}
