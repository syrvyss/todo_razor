using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data.Interfaces;

namespace WebApp.Pages;

public class IssueBoardModel : PageModel {
    private readonly IIssueRepository _issueRepository;
    private readonly ILogger<IssueBoardModel> _logger;

    public IssueBoardModel(ILogger<IssueBoardModel> logger, IIssueRepository issueRepository) {
        _logger = logger;
        _issueRepository = issueRepository;
    }

    public List<Issue> Issues { get; set; } = new();

    public void OnGet() {
        var id = HttpContext.Session.GetString("id");
        Issues = _issueRepository
            .Get()
            .Where(x => x.Id.ToString() == id)
            .ToList();
    }

    public void OnPost() {
        Issues = _issueRepository.Get();
    }
}