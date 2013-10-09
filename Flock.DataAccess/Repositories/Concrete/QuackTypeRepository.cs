using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flock.DataAccess.Base;
using Flock.DataAccess.EntityFramework;
using Flock.DataAccess.Repositories.Interfaces;

namespace Flock.DataAccess.Repositories.Concrete
{
    public class QuackTypeRepository : SqlRepository<QuackType>, IQuackTypeRepository
    {
        public QuackTypeRepository(FlockContext context)
            : base(context)
        {
        }

        public QuackType GetQuackByQuackType(int quackType)
        {
            var quackTypes = base.GetAll().ToList();
            return quackTypes.FirstOrDefault(quack => quack.ID == quackType);
        }
    }
}
