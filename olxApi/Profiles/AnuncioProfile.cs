using AutoMapper; 
using olxApi.Dtos;
using olxApi.Models;

namespace olxApi.Profiles;

public class AnuncioProfile : Profile
{
   public AnuncioProfile()
   {
      CreateMap<CreateAnuncioDto, Anuncio>();
      CreateMap<UpdateAnuncioDto, Anuncio>();
      CreateMap<Anuncio, UpdateAnuncioDto>();
      CreateMap<Anuncio, ReadAnuncioDto>();
      CreateMap<Anuncio, Image>();
      CreateMap<Image, Anuncio>();
      CreateMap<Anuncio, CreateImageDto>();
      CreateMap<CreateImageDto, Anuncio>();
      CreateMap<Anuncio, ReadEditAd>();
      CreateMap<ReadEditAd, Anuncio>();
      CreateMap<Category, ReadEditAd>();
      CreateMap<ReadEditAd, Category>();
   } 
}