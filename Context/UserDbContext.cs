using Eisenhower_Web_API.Models;
using MongoDB.Driver;

namespace Eisenhower_Web_API.Context
{
    public class UserDbContext
    {
        private readonly IMongoDatabase _database;

        public UserDbContext(string connectionString)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("EisenhowerDatabase");
        }

        public IMongoCollection<UserModel> Users => _database.GetCollection<UserModel>("Users");
    }
}
