using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class Issue : IGuid {
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime Created { get; } = DateTime.Now;
    public required Status Status { get; set; }
    public required Priority Priority { get; set; }

    [MaxLength(20)]
    public string Name { get; set; }

    [MaxLength(150)]
    public string Description { get; set; }
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
