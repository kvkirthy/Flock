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
    }
}