
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flock.Models
{
    public class FlockMessage:IEntity<Guid>
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("createDatetime")]
        public DateTime CreateDateTime { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("usersLiked")]
        public List<string> UsersLiked { get; set; }

        [JsonProperty("comments")]
        public List<string> Comments { get; set; }

        [JsonProperty("lastUpdated")]
        public string LastUpdated { get; set; }
    }
}
