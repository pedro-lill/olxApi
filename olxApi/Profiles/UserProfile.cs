using AutoMapper; 
using olxApi.Dtos;
using olxApi.Models;

namespace olxApi.Profiles;

public class UserProfile : Profile
{
   public UserProfile()
   {
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
        CreateMap<User, UpdateUserDto>();
        CreateMap<User, ReadUserDto>();
   } 
}