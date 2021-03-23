using System;
using Microsoft.AspNetCore.Http;

namespace DatingApp.Models.Dtos
{
  public class PhotoCreateDto
  {
    public PhotoCreateDto()
    {
      DateAdded = DateTime.Now;
    }
    public string Url { get; set; }
    public IFormFile File { get; set; }
    public string PublicId { get; set; }
    public string Description { get; set; }
    public DateTime DateAdded { get; set; }

  }
}
