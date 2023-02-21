using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace WebApp.Test;

public class IssueRepositoryTest {
    private readonly IssueRepository _issueRepository = new();

    [Fact]
    public void CreateIssue() {
        // Arrange
        Issue issue = new() {
            Status = Status.Todo,
            Priority = Priority.Low
        };

        // Act
        _issueRepository.Create(issue);

        // Assert
        Assert.Single(_issueRepository.Get().Where(x => x == issue));
    }
    
    [Fact]
    public void ReadIssue() {
        // Arrange
        Issue issue = new() {
            Status = Status.Todo,
            Priority = Priority.Low
        };

        // Act
        _issueRepository.Create(issue);
        Issue expected = _issueRepository.Read(issue.Id.Value);

        // Assert
        Assert.Equal(expected, issue);
    }
    
    [Fact]
    public void UpdateIssue() {
        // Arrange
        Issue issue = new() {
            Status = Status.Todo,
            Priority = Priority.Low
        };

        // Act
        _issueRepository.Create(issue);

        issue.Status = Status.Doing;
        
        _issueRepository.Update(issue);

        // Assert
        Issue query = _issueRepository.Get().Single(x => x.Id == issue.Id);
        Assert.True(query.Status == Status.Doing);
    }
    
    [Fact]
    public void DeleteIssue() {
        // Arrange
        Issue issue = new() {
            Status = Status.Todo,
            Priority = Priority.Low
        };

        // Act
        _issueRepository.Create(issue);
        _issueRepository.Delete(issue.Id.Value);

        // Assert
        Issue? query = _issueRepository.Get().SingleOrDefault(x => x == issue);
        Assert.True(query == null);
    }
    
}