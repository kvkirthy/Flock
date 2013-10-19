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
                .Include("QuackType").ToList();

        }

        IList<Quack> IQuackRepository.GetAllQuacks()
        {
            var quacks = _context.Quacks
                .Include("QuackContent")
                .Include("User")
                .Include("QuackType");
            //TODO: Paging
            return quacks.Where(quack => quack.Active)
                .OrderByDescending(quack => quack.CreatedDate )
                .Take(200)
                .ToList();
        }

        public void DeleteQuack(int quackId)
        {
            var quack = base.GetById(quackId);
            quack.Active = false;
            base.Update(quack);
        }

        public void UpdateQuack(int quackId)
        {
            var currentQuack = base.GetById(quackId);
            currentQuack.LastModifiedDate = DateTime.Now;
            base.Update(currentQuack);
        }

        public IList<Quack>  GetAllReplies(int quackId)
        {
            var quacks = _context.Quacks
                .Include("QuackContent")
                .Include("User")
                .Include("QuackType");
            //TODO: Paging
            return quacks.Where(quack => quack.Active && quack.QuackTypeID == 2 && quack.ConversationID == quackId)
                .OrderBy(quack => quack.CreatedDate)
                .Take(200)
                .ToList();
        }

        public IList<Quack > GetQuacksInfo(int conversationId)
        {
            var quacks = _context.Quacks
                .Include("QuackContent")
                .Include("User")
                .Include("QuackType");
            //TODO: Paging
            return quacks.Where(quack => quack.Active && ( quack.ConversationID == conversationId || quack.ID == conversationId ))
                .OrderBy(quack => quack.CreatedDate)
                .Take(200)
                .ToList();
        }
    }
}
