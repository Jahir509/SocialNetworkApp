using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Data;
using DatingApp.Models;
using DatingApp.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Repository
{
  public class UserRepository:IUserRepository
  {
    private readonly DataContext _context;
    public UserRepository(DataContext context)
    {
      _context = context;
    }
    public async Task<IEnumerable<User>> GetUsers()
    {
      return await _context.Users.Include(p=>p.Photos).ToListAsync();
    }

    public async Task<User> GetUser(int id)
    {
      return await _context.Users.Include(p=>p.Photos).FirstOrDefaultAsync(c => c.Id == id);
    }
  }
}
