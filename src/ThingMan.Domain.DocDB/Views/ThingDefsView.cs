using AutoMapper;
using ThingMan.Domain.Dtos;
using ThingMan.Domain.Entities;
using ThingMan.Domain.Repositories;
using ThingMan.Domain.Views;

namespace ThingMan.Domain.DocDB.Views;

public class ThingDefsView : IThingDefsView
{
    private readonly IMapper _mapper;
    private readonly IThingDefsRepository<ThingDef> _thingDefsRepository;

    public ThingDefsView(IThingDefsRepository<ThingDef> thingDefsRepository, IMapper mapper)
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