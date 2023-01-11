using AutoMapper;
using ThingMan.Domain.Aggregates.ThingDefs;
using ThingMan.Domain.Aggregates.ThingDefs.Dtos;

namespace ThingMan.Domain.Configuration;

public class DomainMappingProfile : Profile
{
    public DomainMappingProfile()
    {
        CreateMap<ThingDef, ThingDefDto>()
            .ReverseMap();

        CreateMap<PropDef, PropDefDto>()
            .ReverseMap();
    }
}