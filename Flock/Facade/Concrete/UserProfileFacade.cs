//using Flock.Facade.Interfaces;
//using Flock.Models;
//using Flock.Repositories.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace Flock.Facade.Concrete
//{
//    public class UserProfileFacade : IUserProfileFacade
//    {
//        private readonly IUserProfileRepository _userProfileRepository;

//        public UserProfileFacade(IUserProfileRepository userProfileRepository)
//        {
//            _userProfileRepository = userProfileRepository;
//        }

//        public void RegisterUser(UserProfile userProfile)
//        {
//            userProfile.CreateDateTime = DateTime.Now;
//            userProfile.LastUpdated = userProfile.CreateDateTime;
//            _userProfileRepository.Add(userProfile);
//        }

//        public IEnumerable<UserProfile> GetUser()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}