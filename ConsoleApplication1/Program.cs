using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flock.DataAccess.EntityFramework;
using Flock.DataAccess.RepositoryBase;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User
            {
                Active = true,
                AdditionalDetails = "X",
                CreatedDate = DateTime.Now,
                FirstName = "Test",
                LastName = "xyz",
                UserName = "puliCode"
            };

            var rep = new SqlRepository<User>();
            rep.Add(user);
        }
    }
}
