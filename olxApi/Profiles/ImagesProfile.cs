using AutoMapper; 
using olxApi.Dtos;
using olxApi.Models;

namespace olxApi.Profiles;

public class ImagesProfile : Profile
{
   public ImagesProfile()
   {
        CreateMap<CreateImageDto, Image>();
        CreateMap<UpdateImageDto, Image>();
        CreateMap<Image, UpdateImageDto>();
        CreateMap<Image, ReadImageDto>();
   } 
}