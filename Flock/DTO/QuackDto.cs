using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flock.DTO
{
    public class QuackDto
    {
        public int Id { get; set; }
        public byte[] UserImage { get; set; }
        public string UserName  { get; set; }
        public string TimeSpan { get; set; }
        public int Likes { get; set; }
        public int Replies { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public string LikeOrUnlike { get; set; }
        public List<QuackDto> QuackReplies { get; set; }
        public bool IsNew { get; set; }
        public string UserNickName { get; set; }
        public int ConversationId { get; set; }
        public string UserDisplayName { get; set; }
        public QuackDto LatestReply { get; set; }
        public string CommentsInfo { get; set; }
        public byte[] QuackImage { get; set; } 
    }
}