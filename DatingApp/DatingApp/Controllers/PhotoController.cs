using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DatingApp.Helpers;
using DatingApp.Models;
using DatingApp.Models.Dtos;
using DatingApp.Repository.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DatingApp.Controllers
{
  [Authorize]
  [Route("api/User/{userId}/photos")]
  public class PhotoController : ControllerBase
  {
    public IOptions<CloudinarySettings> _cloudinaryConfig;
    private readonly IDatingRepository _repository;
    private readonly IMapper _mapper;
    private Cloudinary _cloudinary;

    // GET

    #region Configuration

    public PhotoController(IDatingRepository _repository,IMapper _mapper,IOptions<CloudinarySettings> cloudinaryConfig)
    {
      // Cloudinary Settings
      _cloudinaryConfig = cloudinaryConfig;
      this._repository = _repository;
      this._mapper = _mapper;

      // Create A cloudinary account
      Account account = new Account(
        _cloudinaryConfig.Value.CloudName,
        _cloudinaryConfig.Value.ApiKey,
        _cloudinaryConfig.Value.ÀpiSecret
      );
      // Assign it to CLoudinart Object
      _cloudinary = new Cloudinary(account);
    }

    #endregion

    #region GetPhoto

    [HttpGet("{id}", Name = "GetPhoto")]
    public async Task<IActionResult> GetPhoto(int id)
    {
      var photoFromRepo =await _repository.GetPhoto(id);


      var photo = _mapper.Map<PhotoDetailsDto>(photoFromRepo);

      return Ok(photo);


    }
    #endregion

    #region AddUserPhotoMethod

    [HttpPost]
    public async Task<IActionResult> AddUserPhoto(int userId, PhotoCreateDto photoCreateDto)
    {
      if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)) return Unauthorized();
      var user = await _repository.GetUser(userId);

      //File Uploading Process
      var file = photoCreateDto.File;
      var uploadResult = new ImageUploadResult();
      if (file.Length > 0)
      {
        var uploadParams = new ImageUploadParams()
        {
          File = new FileDescription(file.Name,stream:Stream.Null),
          Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
        };
        uploadResult = _cloudinary.Upload(uploadParams);
      }

      photoCreateDto.Url = uploadResult.Uri.ToString();
      //photoCreateDto.PublicId = uploadResult.PublicId;

      var photo = _mapper.Map<Photo>(photoCreateDto);

      if (!user.Photos.Any(c => c.IsMain)) photo.IsMain = true;

      user.Photos.Add(photo);

      if (await _repository.SaveAll())
      {
        var photoToReturn = _mapper.Map<PhotoDetailsDto>(photo);
        return CreatedAtRoute("GetPhoto",new {id=photo.Id},photoToReturn);
      }

      return BadRequest("Could Not Add photo");
    }

    #endregion

  }

}
