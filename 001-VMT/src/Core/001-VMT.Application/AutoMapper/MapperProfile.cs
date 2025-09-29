using _001_VMT.Application.Dtos;
using _001_VMT.Domain.Entities;
using AutoMapper;

namespace _001_VMT.Application.AutoMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<RegisterDto, User>()
        .ForMember
        (
            destination => destination.Company,
            options => options.MapFrom
            (
                src => src
            )
        )
        .ReverseMap();

        CreateMap<RegisterDto, Company>()
        .ReverseMap();

        CreateMap<LoginDto, User>().ReverseMap();
    }
}