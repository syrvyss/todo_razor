using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data.Interfaces;

// is this bad?
using WebApp.Models;

namespace WebApp.Pages;

public class LogModel : PageModel {
    private readonly ILogger<LogModel> _logger;
    private readonly IIssueRepository _issueRepository;
    public List<Issue> Issues { get; set; } = new();

    public LogModel(ILogger<LogModel> logger, IIssueRepository issueRepository) {
        _logger = logger;
        _issueRepository = issueRepository;
    }

    public void OnGet() {
        Issues = _issueRepository.Get();
    }
}

