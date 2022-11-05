using AutoMapper;
using ThingMan.Core.Domain.Dtos;
using ThingMan.Core.Domain.Entities;
using ThingMan.Core.Domain.Repositories;
using ThingMan.Core.Domain.Views;

namespace ThingMan.Core.Domain.DocDB.Views;

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