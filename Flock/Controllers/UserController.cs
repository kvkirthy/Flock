using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AttributeRouting;
using AttributeRouting.Web.Mvc;
using Flock.DTO;
using Flock.Facade.Interfaces;
using System;

namespace Flock.Controllers
{
    [RoutePrefix("/api/user")]
    public class UserController : ApiController
    {
        private readonly IUserFacade _userFacade;
        private readonly IImageFacade _imageFacade;

        public UserController(IUserFacade userFacade, IImageFacade imageFacade)
        {
            _userFacade = userFacade;
            _imageFacade = imageFacade;
        }

        [GET("getUser")]
        public UserDto GetUser()
        {
            var userName = HttpContext.Current.User.Identity.Name;
            
            return _userFacade.GetUserDetails(userName);
        }

        [POST("uploadImage")]
        public HttpResponseMessage Post(UserImageDto img)
        {
            var response = _imageFacade.ProcessImageByAction(img);
            return Request.CreateErrorResponse(HttpStatusCode.Created, response);

        }

        [GET("getUserLikesInfo")]
        public List<UserLikesDto> GetUserLikesInfo(int quackId)
        {
            return _userFacade.GetUserLikesInfo(quackId);
        }

        [GET("getUserByUserName")]
        public UserDto GetUserByUserName(string userName)
        {
            return _userFacade.GetUserDetails(userName);
        }
        
        [GET("getUserByLastNameAndFirstName")]
        public UserDto GetUserByLastNameAndFirstName(string lastName, string firstName)
        {
            #region Verify if name information is correct
                if (lastName == null)
                {
                    lastName = "";
                }
                else if (lastName.Equals("undefined"))
                {
                    lastName = "";
                }

                if ( firstName == null)
                {
                    firstName = "";
                }
                else if (firstName.Equals("undefined"))
                {
                    firstName = "";
                }
            #endregion

            return _userFacade.GetUserByLastNameAndFirstName(lastName, firstName);
        }

        [PUT("updateUserPreferences")]
        public HttpResponseMessage Put(UserDto userInfo)
        {
            _userFacade.UpdateUserPreferences(userInfo);
            return Request.CreateResponse(HttpStatusCode.Created, "true");
        }

    }
}
