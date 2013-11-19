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
        private readonly IQuackLikeRepository _quackLikeRepository;
        private readonly IAutoMap _autoMap;
        private readonly IImageFacade _imageFacade;

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

        public void UpdateUserPreferences(UserDto user)
        {
            _userRepository.UpdateUserPreferences(_autoMap.Map<UserDto, User>(user));
        }

        private bool CheckUserGroup(SearchResultCollection searchResults, string groupName)
        {
            var groupCount = searchResults[0].Properties["memberOf"].Count;
            for (var cnt = 0; cnt < groupCount; cnt++)
            {
                var grpName = (String)searchResults[0].Properties["memberOf"][cnt];
                var equalsIndex = grpName.IndexOf(groupName, 1, StringComparison.Ordinal);

                if (equalsIndex > 0) return true;
            }
            return false;
        }



        public UserDto GetUserDetails(string userName)
        {
            //TODO: Urls should move as default vaules in database. This approach is bad
            string defaultCoverPicUrl = "http://" + System.Web.HttpContext.Current.Request.Url.Authority + "/Content/images/defaultCoverPic.png";
            string defaultProfilePicUrl = "http://" + System.Web.HttpContext.Current.Request.Url.Authority + "/Content/images/profilepic.png";

            var currentUser = _userRepository.GetUserByUserName(userName);
            if (currentUser == null)
            {
                currentUser = ReadUserDetailsFromActiveDirectory(userName);
                if (currentUser != null)
                {
                    //currentUser.CoverImage = _imageFacade.GetImageFromUrl(defaultCoverPicUrl);
                    //currentUser.ProfileImage = _imageFacade.GetImageFromUrl(defaultProfilePicUrl);

                    _userRepository.SaveUser(currentUser);
                    return _autoMap.Map<User, UserDto>(currentUser);
                }
                return null;
            }
            return _autoMap.Map<User, UserDto>(currentUser);
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
                if (results.Count == 1)
                {
                    if (!CheckUserGroup(results, "HYD_FrontOfficeSuite")) return null;


                    //TODO: seperate out firstname and lastname from the name and assign properly
                    currentUser.UserName = userName;
                    var name = results[0].Properties["name"][0].ToString();
                    name = name.Replace("(DS)", "");
                    name = name.Replace(" ", "");
                    string[] names = name.Split(',');
                    if (names.Count() > 1)
                    {
                        currentUser.FirstName = names[1];
                        currentUser.LastName = names[0];
                    }
                    else
                    {
                        currentUser.FirstName = name;
                        currentUser.LastName = "";
                    }
                    currentUser.EmailId = results[0].Properties["mail"][0].ToString();
                    currentUser.Active = true;
                    currentUser.AdditionalDetails = "Addtional Details";
                    currentUser.CreatedDate = DateTime.Now;
                }
            }
            return currentUser;
        }

        public List<UserLikesDto> GetUserLikesInfo(int quackId)
        {
            var userLikesInfo = _quackLikeRepository.GetUserLikesInfo(quackId);
            var result = new List<UserLikesDto>();

            foreach (var usr in userLikesInfo)
            {
                var userDto = new UserLikesDto();
                var user = _userRepository.GetUserById(usr.UserId);
                userDto.UserPic = user.ProfileImage;
                userDto.UserName = user.FirstName + " " + user.LastName;
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

        public UserDto GetUserByLastNameAndFirstName(string lastName, string firstName)
        {
            return _autoMap.Map<User, UserDto>(_userRepository.GetUserByLastAndFirstName(lastName, firstName));
        }
    }
}
