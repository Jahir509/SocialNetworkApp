using System;
using System.Collections;
using System.Collections.Generic;
using DatingApp.Policies;

namespace DatingApp.Models
{
  public class User:ILog,IAddress
  {
    public long Id { get; set; }
    public string Username { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string Gender { get; set; }
    public string KnownAs { get; set; }
    public string Introduction { get; set; }
    public string LookingFor { get; set; }
    public string Interests { get; set; }
    public ICollection<Photo> Photos { get; set; }
    public DateTime DateOfBirth { get; set; }


    // Contracts ------------------------------
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime LastActive { get; set; }
    public string? HouseNo { get; set; }
    public string? RoadNo { get; set; }
    public string Area { get; set; }
    public string City { get; set; }
    public string? Zip { get; set; }
    public string Country { get; set; }
  }
}
