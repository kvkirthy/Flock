using System.Collections.Generic;
using System.Linq;
using Flock.DataAccess.EntityFramework;
using Flock.DataAccess.Repositories.Interfaces;
using Flock.Facade.Interfaces;
using System;


namespace Flock.Facade.Concrete
{
    public class QuackFacade : IQuackFacade
    {
        private readonly IQuackRepository _quackRepository;

        public QuackFacade(IQuackRepository quackRepository)
        {
            _quackRepository = quackRepository;
        }


        public void SaveQuack(Quack quack)
        {
            _quackRepository.SaveQuack(quack);
        }
    }
}