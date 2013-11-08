using Flock.DataAccess.EntityFramework;
using System.Collections.Generic;
namespace Flock.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {

        IEnumerable<User> GetAllUsers();
        User GetUserByUserName(string userName);

        User GetUserByLastAndFirstName(string lastName, string firstName);

        void SaveUser(User user);
        User GetUserById(int id);
        void UpdateUserCoverImage(User user);
        void UpdateUserProfileImage(User user);
        void UpdateUserPreferences(User user);
    }
}
