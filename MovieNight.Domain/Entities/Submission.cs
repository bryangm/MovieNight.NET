using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MovieNight.Domain.Entities
{
    public class Submission
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string MovieId { get; set; }
        public string Title { get; set; }
        public int Votes { get; set; }
    }
}
