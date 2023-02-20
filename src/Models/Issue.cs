using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class Issue : IGuid {
    public Guid? Id { get; init; }
    public DateTime? Created { get; init; }
    public required Status Status { get; set; }
    public required Priority Priority { get; set; }

    [MaxLength(20)] public string? Name { get; set; }

    [MaxLength(150)] public string? Description { get; set; }

    public Issue() {
        Id ??= Guid.NewGuid();
        Created = DateTime.Now;
    }
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
