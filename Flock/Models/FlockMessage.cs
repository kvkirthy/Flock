using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flock.Models
{
    public class FlockMessage
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("createDateTime")]
        public DateTime CreateDateTime { get; set; }

        [JsonProperty("createUserId")]
        public string CreateUserId { get; set; }

        [JsonProperty("isLiked")]
        public bool IsLiked { get; set; }
    }
}
