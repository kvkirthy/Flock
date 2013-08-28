using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flock.Models;
using Flock.Repositories.Base;

namespace Flock.Repositories.Interfaces
{
    public interface IMessageRepository :IRepository<FlockMessage,Guid>
    {
    }
}