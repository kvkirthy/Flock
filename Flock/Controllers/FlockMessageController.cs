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
//    [RoutePrefix("/api/flockMessage")]
//    public class FlockMessageController : ApiController
//    {
//        private readonly IMessageFacade _messageFacade;

//        public FlockMessageController(IMessageFacade messageFacade)
//        {
//            _messageFacade = messageFacade;
//        }

//        [GET("messages")]
//        public IEnumerable<FlockMessage> GetAll()
//        {
//           return _messageFacade.GetAllMessages();

//        }

//        [POST("message")]
//        public HttpResponseMessage Post(FlockMessage message)
//        {
//            _messageFacade.SaveMessage(message);
//            return Request.CreateResponse(HttpStatusCode.Created, message);
//        }

//        [PUT("message")]
//        public HttpResponseMessage Put(FlockMessage message)
//        {
//            _messageFacade.UpdateMessage(message);
//            return Request.CreateResponse(HttpStatusCode.Created, message);
//        }
//    }
//}
