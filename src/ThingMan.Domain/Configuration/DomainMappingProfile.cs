using AutoMapper;
using ThingMan.Domain.Aggregates.ThingDefs;
using ThingMan.Domain.Aggregates.ThingDefs.Dtos;

namespace ThingMan.Domain.Configuration;

public class DomainMappingProfile : Profile
{
    public DomainMappingProfile()
    {
        // CreateMap<int, Enumeration>().ForMember(dest => dest.Id,
        //     opt => opt.MapFrom(src => Enumeration.FromValue<ENUM WILL GO HERE>(src)));
        //
        // CreateMap<string, Enumeration>().ForMember(dest => dest.Id,
        //     opt => opt.MapFrom(src => Enumeration.FromDisplayName<ENUM WILL GO HERE>(src)));

        CreateMap<ThingDef, ThingDefDto>()
            .ReverseMap();

        CreateMap<PropDef, PropDefDto>()
            .ReverseMap();
    }
}