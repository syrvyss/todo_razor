using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApp.Models;

public class Issue : IGuid {
    public Issue() {
        Id ??= Guid.NewGuid();
        Created = DateTime.Now;
    }

    [BsonElement("created")] public DateTime? Created { get; init; }

    [BsonElement("status")] public required Status Status { get; set; }
    [BsonElement("priority")] public required Priority Priority { get; set; }

    [MaxLength(20)] [BsonElement("name")] public string? Name { get; set; }

    [MaxLength(150)]
    [BsonElement("description")]
    public string? Description { get; set; }

    //  [BsonElement("user")] public User? User { get; set; }
    [BsonElement("user")] public string? User { get; set; }

    [BsonElement("_id")] public Guid? Id { get; init; }
}

public enum Priority {
    Low,
    Normal,
    High
}

public enum Status {
    Todo,
    Doing,
    Done
}