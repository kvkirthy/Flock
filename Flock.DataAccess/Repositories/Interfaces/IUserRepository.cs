using Flock.DataAccess.EntityFramework;
namespace Flock.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByUserName(string userName);
        void SaveUser(User user);
        User GetUserById(int id);
    }
}
