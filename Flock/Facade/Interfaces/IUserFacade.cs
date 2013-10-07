using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flock.DataAccess.EntityFramework;
using Flock.Models;

namespace Flock.Facade.Interfaces
{
    public interface IUserFacade
    {
        User GetUserDetails(string userName);
    }
}