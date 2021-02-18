using System.Collections.Generic;
using System.Linq;
using DatingApp.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Newtonsoft.Json;

namespace DatingApp.Data
{
  public class Seed
  {
    public static void SeedUsers(DataContext context)
    {
      if (!context.Users.Any())
      {
        var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
        // Covert JsonData to Model Object
        var users = JsonConvert.DeserializeObject<List<User>>(userData);

        foreach (var user in users)
        {
          byte[] passwordHash, passwordSalt;
          CreatePasswordHash("password", out passwordHash, out passwordSalt);
          user.PasswordHash = passwordHash;
          user.PasswordSalt = passwordSalt;
          user.Username = user.Username.ToLower();
          context.Users.Add(user);
        }

        context.SaveChanges();
      }
    }

    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passWordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512())
      {
        passWordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      }
    }
  }
}
