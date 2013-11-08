

using System.Linq;
using Flock.DataAccess.Base;
using Flock.DataAccess.EntityFramework;
using Flock.DataAccess.Repositories.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace Flock.DataAccess.Repositories.Concrete
{
    public class UserRepository : SqlRepository<User>, IUserRepository
    {
        public UserRepository(FlockContext context)
            : base(context)
        {
        }

        public IEnumerable<User> GetAllUsers()
        {
            return base.GetAll();
        }

        public User GetUserByUserName(string userName)
        {
            var users = base.GetAll();
            return users.FirstOrDefault(user => user.UserName == userName);
        }

        public void SaveUser(User user)
        {
            base.Add(user);
        }

        public void UpdateUserCoverImage(User user)
        {
            var currentUser = base.GetById(user.ID);
            currentUser.CoverImage = user.CoverImage;
            base.Update(currentUser);
        }

        public void UpdateUserProfileImage(User user)
        {
            var currentUser = base.GetById(user.ID);
            currentUser.ProfileImage = user.ProfileImage;
            base.Update(currentUser);
        }

        public User GetUserById(int id)
        {
            return base.GetById(id);
        }

        public void UpdateUserPreferences(User user)
        {
            var userInfo = base.GetById(user.ID);
            userInfo.Project = user.Project;
            userInfo.Interests = user.Interests;
            base.Update(userInfo);
        }


        public User GetUserByLastAndFirstName(string lastName, string firstName)
        {
            var users = base.GetAll();
            return users.FirstOrDefault(user =>
                user.LastName.Equals(lastName)
                && user.FirstName.Equals(firstName));
        }
    }
}
