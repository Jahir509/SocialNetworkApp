using System.Threading.Tasks;
using DatingApp.Models;
using DatingApp.Models.Dtos;

namespace DatingApp.Service.Contracts.IAuthService
{
  public interface IAuthService
  {
    Task<string> GenerateToken(User userDto);
  }
}
