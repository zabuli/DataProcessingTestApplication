using Application.Contract.Dtos;
using AutoMapper;
using Domain.Models;

namespace Repositories.Mapping
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<SymbolDto, Symbol>().ReverseMap();
            CreateMap<IndicatorDto, Indicator>().ReverseMap();
            CreateMap<ParameterDto, Parameter>().ReverseMap();
        }
	}
}