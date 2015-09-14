using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MovieNight.Domain.Entities
{
    public class Person
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
