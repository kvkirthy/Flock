using AutoMapper;
using Flock.DTO;
using Flock.DataAccess.EntityFramework;

namespace Flock.Infrastructure.MapperProfile
{
    public class FacadeProfile : Profile
    {
        protected override void Configure()
        {
            ApplyTwoWayMapping<UserDto, User>();
        }

        private void ApplyTwoWayMapping<TSource1, TSource2>()
        {
            CreateMap<TSource1, TSource2>();
            CreateMap<TSource2, TSource1>();
        }
    }
}