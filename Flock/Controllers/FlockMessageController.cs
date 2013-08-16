using Flock.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Flock.Controllers
{
    public class FlockMessageController : ApiController
    {
        public IEnumerable<FlockMessage> Get()
        {

            return new List<FlockMessage>()
            {
                new FlockMessage(){
                    Message = "sample message 1",
                    CreateDateTime = DateTime.Now,
                    CreateUserId= "User 1"
                },
                new FlockMessage(){
                    Message = "sample message 2",
                    CreateDateTime = DateTime.Now,
                    CreateUserId= "User 1"
                },
                 new FlockMessage(){
                    Message = "sample message 3",
                    CreateDateTime = DateTime.Now,
                    CreateUserId= "User 2"
                 }
              

            };
        }
    }
}
