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
        private readonly IQuackLikeRepository  _quackLikeRepository;
        private readonly IAutoMap _autoMap;
        private readonly IImageFacade  _imageFacade;

        public UserFacade(IUserRepository userRepository, IAutoMap autoMap, IImageFacade imageFacade, IQuackLikeRepository quackLikeRepository)
        {
            _userRepository = userRepository;
            _autoMap = autoMap;
            _imageFacade = imageFacade;
            _quackLikeRepository = quackLikeRepository;
        }

        public void SaveUser(UserDto user)
        {
            _userRepository.SaveUser(_autoMap.Map<UserDto, User>(user));
        }

        public void UpdateUser(UserDto user)
        {
         
        }


        public UserDto GetUserDetails(string userName)
        {
            //TODO: Urls should move as default vaules in database. This approach is bad
            string defaultCoverPicUrl = "http://" + System.Web.HttpContext.Current.Request.Url.Authority + "/Content/images/defaultCoverPic.png";
            string defaultProfilePicUrl = "http://" + System.Web.HttpContext.Current.Request.Url.Authority + "/Content/images/profilepic.png";
            
            var currentUser = _userRepository.GetUserByUserName(userName);
            if(currentUser == null)
            {
                currentUser = ReadUserDetailsFromActiveDirectory(userName);
                if(currentUser!=null )
                {

                    currentUser.CoverImage = _imageFacade.GetImageFromUrl(defaultCoverPicUrl);
                    currentUser.ProfileImage = _imageFacade.GetImageFromUrl(defaultProfilePicUrl);

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

        public List<UserLikesDto > GetUserLikesInfo(int quackId)
        {
            var userLikesInfo = _quackLikeRepository.GetUserLikesInfo(quackId);
            var result = new List<UserLikesDto>();

            foreach(var usr in userLikesInfo )
            {
                var userDto = new UserLikesDto();
                var user = _userRepository.GetUserById(usr.UserId);
                userDto.UserPic = user.ProfileImage;
                userDto.UserName = user.FirstName;
                result.Add(userDto);
            }
            return result;
        }

        IEnumerable<string> IUserFacade.GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            var returnUsers = new List<string>();
            foreach (var user in users)
            {
                returnUsers.Add(user.UserName);
            }

            return returnUsers;
        }
    }
}
