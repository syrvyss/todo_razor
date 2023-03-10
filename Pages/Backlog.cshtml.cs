using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data.Interfaces;

namespace WebApp.Pages;

public class BacklogModel : PageModel {
    private readonly IIssueRepository _issueRepository;
    private readonly ILogger<IndexModel> _logger;

    public BacklogModel(ILogger<IndexModel> logger, IIssueRepository issueRepository) {
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
}