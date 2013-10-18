using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AttributeRouting;
using AttributeRouting.Web.Mvc;
using Flock.DTO;
using Flock.Facade.Interfaces;

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
    }
}
