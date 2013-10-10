using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flock.DataAccess.EntityFramework;


namespace Flock.Facade.Interfaces
{
    public interface IQuackFacade
    {
        void SaveQuack(Quack quack);
        void GetQuack(int id);
    }
}