using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flock.DTO;
using Flock.DataAccess.EntityFramework;


namespace Flock.Facade.Interfaces
{
    public interface IQuackFacade
    {
        void SaveQuack(Quack quack);
        void GetQuack(int id);
        IList<QuackDto> GetAllQuacks();

        IList<QuackDto> GetQuacksByLastNameAndFirstName(string lastName, string firstName);

        void DeleteQuack(int id);
        void LikeOrUnlikeQuack(int quackId, int userId, Boolean isLike);
        IList<QuackDto> GetQuacksInfo(int conversationId);
    }
}