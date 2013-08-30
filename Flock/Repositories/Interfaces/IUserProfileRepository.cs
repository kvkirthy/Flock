using Flock.Models;
using Flock.Repositories.Base;
using System;

namespace Flock.Repositories.Interfaces
{
    public interface IUserProfileRepository : IRepository<UserProfile, Guid>
    {
    }
}