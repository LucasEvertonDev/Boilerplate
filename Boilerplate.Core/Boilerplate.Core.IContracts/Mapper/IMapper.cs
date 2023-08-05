namespace Boilerplate.Core.IContracts.Mapper;

public interface IAppMapper
{
    TDestination Map<TDestination>(object source) where TDestination : class;
}
