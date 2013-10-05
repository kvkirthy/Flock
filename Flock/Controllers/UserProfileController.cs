//using System.Web.Services.Description;
//using AttributeRouting;
//using AttributeRouting.Web.Mvc;
//using Flock.Facade;
//using Flock.Facade.Interfaces;
//using Flock.Models;
//using Flock.Repositories.Interfaces;
//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http;

//namespace Flock.Controllers
//{
//    [RoutePrefix("/api/userProfile/profile")]
//    public class UserProfileController : ApiController
//    {
//        private readonly IUserProfileFacade _userProfileFacade;

//        public UserProfileController(IUserProfileFacade userProfileFacade)
//        {
//            _userProfileFacade = userProfileFacade;
//        }

//        [GET("profile")]
//        public IEnumerable<UserProfile> GetAll()
//        {
//            return _userProfileFacade.GetUser();

//        }

//        [POST("profile")]
//        public HttpResponseMessage Post(UserProfile userProfile)
//        {
//            _userProfileFacade.RegisterUser(userProfile);
//            return Request.CreateResponse(HttpStatusCode.Created, userProfile);
//        }
//    }
//}
