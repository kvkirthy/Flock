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
    public class QuackRepository : SqlRepository<Quack>, IQuackRepository 
    {
        public QuackRepository(FlockContext context)
            : base(context)
        {
        }

        public void SaveQuack(Quack quack)
        {
            base.Add(quack);
        }
    }
}
