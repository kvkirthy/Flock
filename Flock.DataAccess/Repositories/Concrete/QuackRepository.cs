using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flock.DataAccess.Base;
using Flock.DataAccess.EntityFramework;
using Flock.DataAccess.Repositories.Interfaces;
using System.Data.Entity;  

namespace Flock.DataAccess.Repositories.Concrete
{
    public class QuackRepository : SqlRepository<Quack>, IQuackRepository
    {
        private readonly FlockContext _context;
        public QuackRepository(FlockContext context)
            : base(context)
        {
            _context = context;
        }

        public void SaveQuack(Quack quack)
        {
            base.Add(quack);
        }


        public void GetQuack(int id)
        {
            var quack = _context.Quacks
                .Where(q => q.ID == id)
                .Include("QuackContent")
                .Include("User")
                .Include("QuackType").ToList() ;

        }

        IEnumerable<Quack> IQuackRepository.GetAllQuacks()
        {
            return _context.Quacks
                .Include("QuackContent")
                .Include("User")
                .Include("QuackType").ToList();
        }
    }
}
