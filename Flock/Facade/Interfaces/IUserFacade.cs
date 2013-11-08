using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flock.DTO;
using Flock.DataAccess.EntityFramework;

namespace Flock.Facade.Interfaces
{
    public interface IUserFacade
    {
        UserDto GetUserByLastNameAndFirstName(string lastName, string firstName);
        UserDto GetUserDetails(string userName);
        void SaveUser(UserDto user);
        void UpdateUserPreferences(UserDto user);
        List<UserLikesDto> GetUserLikesInfo(int quackId);
        
        IEnumerable<string> GetAllUsers();
    }
}