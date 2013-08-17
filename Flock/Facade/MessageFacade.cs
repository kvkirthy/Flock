using Flock.DataAccess;
using Flock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flock.Facade
{
    public static class MessageFacade
    {
        private static IFlockMessageAccess _flockMessageAccess;
        static MessageFacade()
        {
            _flockMessageAccess = new FlockMessageAccess();
        }

        public static IEnumerable<FlockMessage> getMessages(string givenUserId)
        {
            return _flockMessageAccess.getMessages(givenUserId);
        }
    }
}