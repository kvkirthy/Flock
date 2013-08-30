using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flock.Models;
using Flock.Repositories.Base;
using Flock.Repositories.Interfaces;
using Raven.Client;

namespace Flock.Repositories.Concrete
{
    public class UserProfileRepository : RavenRepository<UserProfile, Guid>, IUserProfileRepository
    {
        public UserProfileRepository(IDocumentSession session)
            : base(session)
        {
        }
    }
}