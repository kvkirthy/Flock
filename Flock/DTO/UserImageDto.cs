using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flock.DTO
{
    public class UserImageDto
    {
        public string SourceUrl { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public String Action { get; set; }
        public int UserId { get; set; }
    }
}