using System;

namespace DatingApp.Policies
{
  public interface ILog
  {
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime LastActive { get; set; }
  }
}
