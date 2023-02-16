namespace WebApp.Models;

public class Issue : IGuid {
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime Created { get; } = DateTime.Now;
    public Status Status { get; set; }
    public Priority Priority { get; set; }
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
