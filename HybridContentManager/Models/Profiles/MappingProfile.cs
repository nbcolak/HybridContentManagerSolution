using AutoMapper;
using HybridContentManager.Models.Dtos;

namespace HybridContentManager.Models.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));

        CreateMap<BookDto, Book>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => int.Parse(src.Id)));
    }
}