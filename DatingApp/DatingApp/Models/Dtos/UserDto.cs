using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.Models.Dtos
{
  public class UserDto
  {
    public long Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Gender { get; set; }
    public string KnownAs { get; set; }
    public string PhotoUrl { get; set; }
    public string Introduction { get; set; }
    public string Interests { get; set; }
    public int Age { get; set; }
    public ICollection<PhotoDetailsDto> Photos { get; set; }


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
