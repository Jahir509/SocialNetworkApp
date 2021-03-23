using System.Linq;
using AutoMapper;
using DatingApp.Models;
using DatingApp.Models.Dtos;

namespace DatingApp.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
      CreateMap<User, UserDto>()
        .ForMember(dest => dest.PhotoUrl,
          opt => opt.MapFrom(
            src => src.Photos.FirstOrDefault(p => p.IsMain == true).Url))  //Adding Photo Property from User to UserDto Model
        .ForMember(dest => dest.Age,
          opt => opt.MapFrom(
            src => src.DateOfBirth.CalculateAge()));  //Adding Age Property from User to UserDto Model Using DateTime


      CreateMap<User, UserDetailsDto>()
        .ForMember(dest => dest.PhotoUrl, 
          opt => opt.MapFrom(
            src => src.Photos.FirstOrDefault(p => p.IsMain == true).Url))   //Adding Photo Property from User to UserDetailsDto Model
        .ForMember(dest => dest.Age,
          opt => opt.MapFrom(
            src => src.DateOfBirth.CalculateAge()));    //Adding Age Property from User to UserDetailsDto Model Using DateTime


      CreateMap<Photo, PhotoDetailsDto>();
      CreateMap<PhotoDetailsDto,Photo>();
    }
  }
}
