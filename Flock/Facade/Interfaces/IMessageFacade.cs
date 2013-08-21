using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flock.Models;

namespace Flock.Facade.Interfaces
{
    public interface  IMessageFacade
    {
        void SaveMessage(FlockMessage message);
        IEnumerable<FlockMessage> GetAllMessages();
        void UpdateMessage(FlockMessage message);
    }
}