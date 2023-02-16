namespace WebApp.Models;

public class Issue : IGuid {
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime Created { get; } = DateTime.Now;
    public required Status Status { get; set; }
    public required Priority Priority { get; set; }

    public string Name {
        get { return this.Name; }
        set {
            if (value.Length > 20) {
                Name = value;
            }
        }
    }

    public string Description {
        get { return this.Description; }
        set {
            if (value.Length > 100) {
                Description = value;
            }
        }
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
