using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MovieNight.Domain.Entities
{
    public class Night
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime ViewBy { get; set; }
        public List<Submission> Submissions { get; set; }
    }
}
