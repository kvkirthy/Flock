using System.Collections.Generic;
using System.Linq;
using Flock.DTO;
using Flock.DataAccess.Base;
using Flock.DataAccess.EntityFramework;
using Flock.DataAccess.Repositories.Interfaces;
using Flock.Facade.Interfaces;
using System;


namespace Flock.Facade.Concrete
{
    public class QuackFacade : IQuackFacade
    {
        private readonly IQuackRepository _quackRepository;
        private readonly IQuackTypeRepository _quackTypeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IQuackLikeRepository _quackLikeRepository;

        public QuackFacade(IQuackRepository quackRepository, IQuackTypeRepository quackTypeRepository, IUserRepository userRepository, IQuackLikeRepository quackLikeRepository)
        {
            _quackRepository = quackRepository;
            _quackTypeRepository = quackTypeRepository;
            _userRepository = userRepository;
            _quackLikeRepository = quackLikeRepository;
        }


        public void SaveQuack(Quack quack)
        {
            quack.CreatedDate = DateTime.Now;
            quack.LastModifiedDate = DateTime.Now;
            quack.Active = true;
            var quackType = _quackTypeRepository.GetQuackByQuackType(quack.QuackTypeID);

            quack.QuackType = quackType;
            var user = _userRepository.GetUserById(quack.UserID);
            quack.User = user;

            quack.QuackContent.CreatedDate = DateTime.Now;
            _quackRepository.SaveQuack(quack);

        }

        public void GetQuack(int id)
        {
            _quackRepository.GetQuack(id);


        }

        private string VerifyLikeOrUnLike(Quack quack)
        {
            var check = quack.QuackLikes.FirstOrDefault(q => q.UserId == quack.UserID && q.Active && q.QuackId ==quack.ID );
            return check == null ? "Like" : "UnLike";
        }

        public IList<QuackDto> GetAllQuacks()
        {
            var quacks = _quackRepository.GetAllQuacks();

            return quacks.Select(quack => new QuackDto
                                              {
                                                  Id = quack.ID,
                                                  Likes = quack.QuackLikes.Count(q => q.Active),  
                                                  Message = quack.QuackContent.MessageText,
                                                  Replies = 10,
                                                  TimeSpan = GetTimeSpanInformation(quack.CreatedDate),
                                                  UserName = quack.User.FirstName,
                                                  UserImage = quack.User.ProfileImage,
                                                  UserId = quack.User.ID,
                                                  LikeOrUnlike = VerifyLikeOrUnLike(quack)

                                              }).ToList();
        }

        private string GetTimeSpanInformation(DateTime date)
        {
            TimeSpan timeSpan = DateTime.Now.Subtract(date);
            var result = "";

            if (timeSpan.Days > 2)
            {
                result = date.ToString("MMMM dd, yyyy") + " at " + date.ToString("hh:mm tt");
            }
            else if (timeSpan.Days > 0)
            {
                result = timeSpan.Days + " days ago";
            }
            else if (timeSpan.Hours > 0)
            {
                result = timeSpan.Hours + " hours ago";
            }
            else if (timeSpan.Minutes > 0)
            {
                result = timeSpan.Minutes + " minutes ago";
            }
            else
            {
                result = "Few seconds ago";
            }
            return result;
        }

        public void DeleteQuack(int id)
        {
            _quackRepository.DeleteQuack(id);
        }

        public void LikeOrUnlikeQuack(int quackId, int userId, Boolean isLike)
        {
            var quackLike = new QuackLike { QuackId = quackId, UserId = userId, Active = isLike };
            _quackLikeRepository.UpdateQuackLike(quackLike);
        }

    }
}