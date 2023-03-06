using AutoMapper; 
using olxApi.Dtos;
using olxApi.Models;

namespace olxApi.Profiles;

public class ImagesProfile : Profile
{
   public ImagesProfile()
   {
        CreateMap<CreateImagesDto, Image>();
        CreateMap<UpdateImagesDto, Image>();
        CreateMap<Image, UpdateImagesDto>();
        CreateMap<Image, ReadImagesDto>();
   } 
}