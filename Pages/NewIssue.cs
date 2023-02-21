using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data.Interfaces;
using WebApp.Data.Repositories;
using WebApp.Models;
using WebApp.Models.Controller;

namespace WebApp.Pages;

public class NewIssueModel : PageModel {
    private readonly ILogger<IndexModel> _logger;
    private readonly IIssueRepository _issueRepository;

    [BindProperty] public Issue Issue { get; set; }

    public NewIssueModel(ILogger<IndexModel> logger, IIssueRepository issueRepository) {
        _logger = logger;
        _issueRepository = issueRepository;
    }

    public void OnGet() {
    }

    public IActionResult OnPost(Issue Issue) {
        if (ModelState.IsValid) {
            _issueRepository.Create(Issue);

            return RedirectToPage("/IssueBoard");
        }

        return Page();
    }
}