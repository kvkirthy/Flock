﻿using System.DirectoryServices;
using System.Web;
using System.Web.Security;
using System.Web.Services.Description;
using AttributeRouting;
using AttributeRouting.Web.Mvc;
using Flock.DataAccess.EntityFramework;
using Flock.Facade;
using Flock.Facade.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http;

namespace Flock.Controllers
{
    [RoutePrefix("/api/quack")]
    public class QuackController : ApiController
    {
        private readonly IQuackFacade _quackFacade;

        public QuackController(IQuackFacade quackFacade)
        {
            _quackFacade = quackFacade;
        }

        [POST("save")]
        public HttpResponseMessage Post(Quack quack)
        {
            _quackFacade.SaveQuack(quack  );
            return Request.CreateResponse(HttpStatusCode.Created, quack);
        }

        
    }
}