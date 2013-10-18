using System.Collections.Generic;

namespace Flock.Infrastructure.MapperProfile
{
    public interface IAutoMap
    {
        TDestination Map<TSource, TDestination>(TSource sourceObject);
        TDestination Map<TSource, TDestination>(TSource sourceObject, TDestination destination);
        IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> sourceObject);
    }
}