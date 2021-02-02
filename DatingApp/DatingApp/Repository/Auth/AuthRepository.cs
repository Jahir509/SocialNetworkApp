using System;
using System.Threading.Tasks;
using DatingApp.Data;
using DatingApp.Models;
using DatingApp.Repository.Contracts.IAuth;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Repository.Auth
{
  public class AuthRepository:IAuthRepository
  {
    private readonly DataContext _context;

    public AuthRepository(DataContext context)
    {
      _context = context;
    }
    public async Task<User> Register(User user, string password)
    {
      byte[] passwordHash, passWordSalt;
      CreatePassword(password, out passwordHash, out passWordSalt);
      user.PasswordHash = passwordHash;
      user.PasswordSalt = passWordSalt;

      await _context.Users.AddAsync(user);
      await _context.SaveChangesAsync();
      return user;
    }

    private void CreatePassword(string password, out byte[] passwordHash, out byte[] passWordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512())
      {
        passWordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      }
    }

    public async Task<User> Login(string username, string password)
    {
      var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
      if (user is null) return null;
      if (!VerifyPassword(password, user.PasswordHash, user.PasswordSalt)) return null;
      return user;
    }

    private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
      {
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        for (int i = 0; i < computedHash.Length; i++)
        {
          if (computedHash[i] != passwordHash[i]) return false;
        }
      }

      return true;
    }

    public async Task<bool> UserExists(string username)
    {
      if (await _context.Users.AnyAsync(x => x.UserName == username)) return true;
      return false;
    }
  }
}
