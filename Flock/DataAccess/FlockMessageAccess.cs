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
            using (var session = MvcApplication.FlockDocumentStore.OpenSession("Flock"))
            {
               var messages= session.Query<FlockMessage>();
               return messages;
            }
        }
    }
}