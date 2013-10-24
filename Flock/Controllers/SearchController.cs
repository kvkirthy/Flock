using AttributeRouting;
using AttributeRouting.Web.Mvc;
using Flock.Facade.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Flock.Controllers
{
    [RoutePrefix("/api/search")]
    public class SearchController : ApiController
    {
        private readonly IUserFacade _userFacade;        

        public SearchController(IUserFacade userFacade, IImageFacade imageFacade)
        {
            _userFacade = userFacade;            
        }

        
        [HttpGet]
        [GET("userTags")]
        public IEnumerable<string> userTags()
        {
            return _userFacade.GetAllUsers();
        }
    }
}
