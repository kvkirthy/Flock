using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flock.DataAccess.EntityFramework;

namespace Flock.DataAccess.Repositories.Interfaces
{
    public interface IQuackTypeRepository
    {
        QuackType GetQuackByQuackType(int quackType);
    }
}
