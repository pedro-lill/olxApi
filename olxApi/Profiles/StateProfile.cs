using AutoMapper;
using olxApi.Dtos;
using olxApi.Models;

namespace olxApi.Profiles;

public class StateProfile : Profile
{
    public StateProfile()
    {
        CreateMap<CreateStateDto, State>();
        CreateMap<UpdateStateDto, State>();
        CreateMap<State, UpdateStateDto>();
        CreateMap<State, ReadStateDto>();
    }
}