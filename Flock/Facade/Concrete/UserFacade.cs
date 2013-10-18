using System.DirectoryServices;
using Flock.DTO;
using Flock.DataAccess.EntityFramework;
using Flock.DataAccess.Repositories.Interfaces;
using Flock.Facade.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Flock.Infrastructure.MapperProfile;

namespace Flock.Facade.Concrete
{
    public class UserFacade : IUserFacade
    {
        private readonly IUserRepository _userRepository;
        private readonly IAutoMap _autoMap;

        public UserFacade(IUserRepository userRepository, IAutoMap autoMap)
        {
            _userRepository = userRepository;
            _autoMap = autoMap;
        }

        public void SaveUser(UserDto user)
        {
            _userRepository.SaveUser(_autoMap.Map<UserDto, User>(user));
        }

        public void UpdateUser(UserDto user)
        {
            //_userRepository.UpdateUser(_autoMap.Map<UserDto, User>(user));
        }


        public UserDto GetUserDetails(string userName)
        {
            var currentUser = _userRepository.GetUserByUserName(userName);
            if(currentUser == null)
            {
                currentUser = ReadUserDetailsFromActiveDirectory(userName);
                if(currentUser!=null )
                {
                    _userRepository.SaveUser(currentUser);
                    return _autoMap.Map<User, UserDto>(currentUser);
                }
            }
            return   _autoMap.Map<User,UserDto>(currentUser ) ;
        }

        private User ReadUserDetailsFromActiveDirectory(string userName)
        {
            var currentUser = new User(); 
            var directory = new DirectoryEntry();
            var userAccountName = userName.Replace("DS\\", "");
            var directorySearcher = new DirectorySearcher { Filter = "(&(objectCategory=person)(objectClass=user)(sAMAccountName=" + userAccountName + "))", SearchRoot = directory };
            using (directorySearcher)
            {
                var results = directorySearcher.FindAll();
                if(results.Count ==1)
                {
                    //TODO: seperate out firstname and lastname from the name and assign properly
                    currentUser.UserName = userName;  
                    currentUser.FirstName = results[0].Properties["name"][0].ToString(); 
                    currentUser.LastName  = results[0].Properties["name"][0].ToString();
                    currentUser.Active = true;
                    currentUser.AdditionalDetails = "Addtional Details";
                    currentUser.CreatedDate = DateTime.Now;
                }
            }
            return currentUser;
        }
    }
}
