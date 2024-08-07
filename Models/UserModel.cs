using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Eisenhower_Web_API.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public byte[]? PasswordHash { get; set; }
        public string? Image {  get; set; }

        [BsonElement("userTasks")]
        public Pool? UserTasks { get; set; }
    }

    public class Pool
    {
        public List<TaskModel>? DoTasks;
        public List<TaskModel>? DelegateTasks;
        public List<TaskModel>? DecideTasks;
        public List<TaskModel>? DeleteTasks;
    }
}
