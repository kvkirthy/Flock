using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flock.DataAccess.Base;
using Flock.DataAccess.EntityFramework;

namespace Flock.DataAccess.Repositories.Interfaces
{
    public interface IQuackRepository
    {
        void SaveQuack(Quack quack);
        void GetQuack(int id);

        IQueryable<Quack> GetQuacksByLastNameAndFirstName(string lastName, string firstName);
        IList<Quack> GetAllQuacks();
        void DeleteQuack(int id);
        void UpdateQuack(int quackId);
        IList<Quack> GetAllReplies(int quackId);
        IList<Quack> GetQuacksInfo(int conversationId);
    }
}
