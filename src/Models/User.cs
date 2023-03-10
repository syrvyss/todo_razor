using MongoDB.Bson.Serialization.Attributes;

namespace WebApp.Models;

public class User : IGuid {
    public User() {
        Id ??= Guid.NewGuid();
    }

    [BsonElement("username")] public string Username { get; set; }

    [BsonElement("password")] public string Password { get; set; }

    [BsonElement("user_id")] public Guid? Id { get; init; }
}