using System.Collections.Generic;
using System.Linq;
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
        private readonly IUserRepository  _userRepository;

        public QuackFacade(IQuackRepository quackRepository, IQuackTypeRepository quackTypeRepository, IUserRepository userRepository)
        {
            _quackRepository = quackRepository;
            _quackTypeRepository = quackTypeRepository;
            _userRepository = userRepository;
        }


        public void SaveQuack(Quack q)
        {
            var quack = new Quack {QuackTypeID = 1, UserID =1, ParentQuackID =null, CreatedDate = DateTime.Now  };
            quack.ConversationID = quack.ID;

            var quackType = _quackTypeRepository.GetQuackByQuackType(quack.QuackTypeID );
            quack.QuackType = quackType;

            var user = _userRepository.GetUserById(quack.UserID);
            quack.User = user;

            var quackContent = new QuackContent {MessageText = "First Quack", CreatedDate = DateTime.Now};
            quack.QuackContent = quackContent;
            
            _quackRepository.SaveQuack(quack);
            GetQuack(5);
        }

        public void GetQuack(int id)
        {
             _quackRepository.GetQuack(id);


        }

        public IEnumerable<QuackEntity> GetAllQuacks()
        {
            var quacks = _quackRepository.GetAllQuacks();

            //TODO: Use Auto-mapper
            var returnData = new List<QuackEntity>();

            foreach(var quack in quacks)
            {
                returnData.Add(new QuackEntity(){
                    ID = quack.ID,
                    UserID = quack.UserID,
                    UserName = quack.User.UserName,
                    ContentID = quack.ContentID,
                    ConversationID = quack.ConversationID,
                    ParentQuackID = quack.ParentQuackID,
                    CreatedDate = quack.CreatedDate,
                    QuackMessage = quack.QuackContent.MessageText
                });
            }

            return returnData;
        }
    }
}