using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Data;
using DatingApp.Models;
using DatingApp.Repository.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Repository
{
  public class DatingRepository : IDatingRepository
  {
    private readonly DataContext _context;
    public DatingRepository(DataContext context)
    {
      _context = context;
    }
    public async void Add<T>(T entity) where T : class
    {
      _context.Add(entity);
    }

    public async void Delete<T>(T entity) where T : class
    {
      _context.Remove(entity);
    }


    public async Task<User> GetUser(int id)
    {
      var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);
      return user;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
      return await _context.Users.Include(p => p.Photos).ToListAsync();
    }

    public async Task<Photo> GetPhoto(int id)
    {

      var photo = await _context.Photos.FirstOrDefaultAsync(c => c.Id == id);
      return photo;
    }

    public async Task<bool> SaveAll()
    {
      return await _context.SaveChangesAsync() > 0;
    }
  }
}
