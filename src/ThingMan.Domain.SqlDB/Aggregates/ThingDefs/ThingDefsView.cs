using AutoMapper;
using ThingMan.Domain.Aggregates.ThingDefs;
using ThingMan.Domain.Aggregates.ThingDefs.Dtos;

namespace ThingMan.Domain.SqlDB.Aggregates.ThingDefs;

internal class ThingDefsView : IThingDefsView
{
    private readonly IMapper _mapper;
    private readonly IThingDefsRepository _thingDefsRepository;

    public ThingDefsView(IThingDefsRepository thingDefsRepository, IMapper mapper)
    {
        _thingDefsRepository = thingDefsRepository;
        _mapper = mapper;
    }

    public async Task<ThingDefDto> GetById(string id)
    {
        var entity = await _thingDefsRepository.ReadAsync(id);
        var retval = _mapper.Map<ThingDefDto>(entity);
        return retval;
    }
}