using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.Models.Dtos
{
  public class UserDetailsDto
  {
    public long Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    [StringLength(8, MinimumLength = 4, ErrorMessage = "Password must be between 4 to 8 character")]
    public string Gender { get; set; }
    public string KnownAs { get; set; }
    public string Interests { get; set; }
    public string PhotoUrl { get; set; }
    public ICollection<PhotoDetailsDto> Photos { get; set; }
    public int Age { get; set; }


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
