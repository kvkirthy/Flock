
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AttributeRouting;
using AttributeRouting.Web.Mvc;
using Flock.DataAccess.EntityFramework;
using Flock.Facade.Interfaces;
using Flock.Models;

namespace Flock.Controllers
{
    [RoutePrefix("/api/user")]
    public class UserController : ApiController
    {
        private readonly IUserFacade _userFacade;

        public UserController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [GET("getUser")]
        public User GetUser()
        {
            var userName = HttpContext.Current.User.Identity.Name;
            return _userFacade.GetUserDetails(userName);
        }
     
    }
}
