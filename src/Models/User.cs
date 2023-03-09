namespace WebApp.Models;

public class User : IGuid {
    public User() {
        Id ??= Guid.NewGuid();
    }

    public string Username { get; set; }
    public string Password { get; set; }

    public Guid? Id { get; init; }
}