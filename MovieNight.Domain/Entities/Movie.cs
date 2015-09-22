using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MovieNight.Domain.Entities
{
    public class Movie
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Rating { get; set; }
        public int Length { get; set; }
        public List<string> Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        [BsonIgnoreIfNull]
        public List<Person> Directors { get; set; }
        [BsonIgnoreIfNull]
        public List<Person> Writers { get; set; }
        [BsonIgnoreIfNull]
        public List<Person> Cast { get; set; } 
    }
}
