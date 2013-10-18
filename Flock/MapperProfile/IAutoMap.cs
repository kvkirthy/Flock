using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flock.MapperProfile
{
    public interface IAutoMap
    {
        TDestination Map<TSource, TDestination>(TSource sourceObject);
        TDestination Map<TSource, TDestination>(TSource sourceObject, TDestination destination);
        IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> sourceObject);
    }
}