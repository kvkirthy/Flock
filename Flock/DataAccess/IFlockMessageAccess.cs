using Flock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flock.DataAccess
{
    interface IFlockMessageAccess
    {
        IEnumerable<FlockMessage> getMessages(string givenUserId);
    }
}
