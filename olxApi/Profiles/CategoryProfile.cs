using AutoMapper; 
using olxApi.Dtos;
using olxApi.Models;

namespace olxApi.Profiles;

public class CategoryProfile : Profile
{
   public CategoryProfile()
   {
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
        CreateMap<Category, UpdateCategoryDto>();
        CreateMap<Category, ReadCategoryDto>();
   } 
}