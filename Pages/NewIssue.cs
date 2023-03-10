using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data.Interfaces;

namespace WebApp.Pages;

public class NewIssueModel : PageModel {
    private readonly IIssueRepository _issueRepository;

    public NewIssueModel(IIssueRepository issueRepository) {
        _issueRepository = issueRepository;
    }

    [BindProperty] public Issue Issue { get; set; }

    public void OnGet() {
    }

    public IActionResult OnPost(Issue Issue) {
        var id = HttpContext.Session.GetString("id");

        if (ModelState.IsValid) {
            _issueRepository.Create(Issue, id);

            return RedirectToPage("/IssueBoard");
        }

        return Page();
    }
}