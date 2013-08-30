using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flock.Models;

namespace Flock.Facade.Interfaces
{
    public interface IUserProfileFacade
    {
        void RegisterUser(UserProfile message);
        IEnumerable<UserProfile> GetUser();
    }
}