using System;

namespace DatingApp.Models.Dtos
{
  public class PhotoDetailsDto
  {
    public long Id { get; set; }
    public string Url { get; set; }
    public string PublicId { get; set; }

    public string Description { get; set; }
    public DateTime DateAdded { get; set; }
    public bool IsMain { get; set; }
  }
}
