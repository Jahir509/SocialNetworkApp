using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Models;
using Microsoft.AspNetCore.Components.Web;

namespace DatingApp.Repository.Contracts
{
  public interface IDatingRepository
  {
    void Add<T> (T entity) where T : class;
    void Delete<T> (T entity) where T : class;

    Task<bool> SaveAll();
    Task<User> GetUser(int id);
    Task<IEnumerable<User>> GetUsers();
    Task<Photo> GetPhoto(int id);
  }
}
