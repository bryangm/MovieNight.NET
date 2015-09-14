using System.Configuration;
using MongoDB.Driver;
using MovieNight.Domain.Entities;

namespace MovieNight.Domain.Repositories.MongoDb
{
    public class MongoDbContext
    {
        private const string ConnectionStringName = "MongoLab";
        private const string DatabaseName = "movienight";
        private const string MoviesCollectionName = "movies";
        private const string NightsCollectionName = "nights";

        public MongoDbContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
            Client = new MongoClient(connectionString);
        }

        public IMongoClient Client { get; set; }
        public IMongoDatabase Database => Client.GetDatabase(DatabaseName);
        public IMongoCollection<Movie> Movies => Database.GetCollection<Movie>(MoviesCollectionName);
        public IMongoCollection<Night> Nights => Database.GetCollection<Night>(NightsCollectionName);
    }
}
