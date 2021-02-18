namespace DatingApp.Policies
{
  public interface IAddress
  {
    public string? HouseNo { get; set; }
    public string? RoadNo { get; set; }
    public string Area { get; set; }
    public string City { get; set; }
    public string? Zip { get; set; }
    public string Country { get; set; }
  }
}
