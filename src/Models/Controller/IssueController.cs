using WebApp.Data.Interfaces;

namespace WebApp.Models.Controller;

public class IssueController {
    private readonly IIssueRepository _issueRepository;

    public IssueController(IIssueRepository issueRepository) {
        _issueRepository = issueRepository;
    }

    public void New(Priority priority) {
        Issue issue = new() {
            Status = Status.Todo,
            Priority = priority
        };

        _issueRepository.Create(issue);
    }
}