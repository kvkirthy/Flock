using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flock.DataAccess.EntityFramework;

namespace Flock.DataAccess.Repositories.Interfaces
{
    public interface  IQuackLikeRepository
    {
        void UpdateQuackLike(QuackLike quackLike);
        List<QuackLike> GetUserLikesInfo(int quackId);
    }
}
