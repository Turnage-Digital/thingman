using AutoMapper;
using ThingMan.Domain.Dtos;
using ThingMan.Domain.Repositories;
using ThingMan.Domain.Views;

namespace ThingMan.Domain.SqlDB.Views;

public class ThingDefsView : IThingDefsView
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