using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data.Interfaces;
using WebApp.Models;
using WebApp.Models;

namespace WebApp.Pages;

public class IssueBoardModel : PageModel {
    private readonly ILogger<IssueBoardModel> _logger;
    private readonly IIssueRepository _issueRepository;
    public List<Issue> Issues { get; set; } = new();

    public IssueBoardModel(ILogger<IssueBoardModel> logger, IIssueRepository issueRepository) {
        _logger = logger;
        _issueRepository = issueRepository;
    }

    public void OnGet() {
        Issues = _issueRepository.Get();
    }

    public void OnPost() {
        Issues = _issueRepository.Get();
    }
}