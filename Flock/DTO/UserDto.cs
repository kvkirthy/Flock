
using System;

namespace Flock.DTO
{
    public class UserDto
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Project { get; set; }
        public string Interests { get; set; }
        public bool Active { get; set; }
        public string AdditionalDetails { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public byte[] CoverImage { get; set; }
        public byte[] ProfileImage { get; set; }
        public String CoverImg { get; set; }
        public String ProfileImg { get; set; }
       
    }
}