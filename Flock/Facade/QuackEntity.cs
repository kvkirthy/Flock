using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flock.Facade
{

    //TODO: Move to a different file.
    public class QuackEntity
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ContentID { get; set; }
        public int QuackTypeID { get; set; }
        public int ConversationID { get; set; }
        public Nullable<int> ParentQuackID { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public string UserName { get; set; }
        public string QuackMessage { get; set; }


    }
}