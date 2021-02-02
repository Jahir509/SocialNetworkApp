using System.ComponentModel.DataAnnotations;

namespace DatingApp.Models.Dtos
{
  public class UserDto
  {
    public long Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    [StringLength(8,MinimumLength = 4,ErrorMessage = "Password must be between 4 to 8 character")]
    public string Password { get; set; }
  }
}
