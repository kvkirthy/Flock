using Flock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flock.DataAccess
{
    public class FlockMessageAccess : IFlockMessageAccess
    {
        public IEnumerable<FlockMessage> getMessages(string givenUserId)
        {
            using (var session = MvcApplication.FlockDocumentStore.OpenSession())
            {
               var messages= session.Query<FlockMessage>("http://localhost:8082/databases/playground/docs");
               return messages;
            }
        }
    }
}