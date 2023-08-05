
using AutoMapper;

namespace Boilerplate.Infra.Plugins.AutoMapper;

public class Mapper : Core.IContracts.Mapper.IAppMapper
{
    private readonly IMapper _mapper;

    public Mapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TDestination Map<TDestination>(object source) where TDestination : class
    {
        return _mapper.Map<TDestination>(source);
    }
}
