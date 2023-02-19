using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data.Interfaces;
using WebApp.Data.Repositories;
using WebApp.Models;
using WebApp.Models.Controller;

namespace WebApp.Pages;

public class EditIssueModel : PageModel {
    private readonly ILogger<IndexModel> _logger;
    private readonly IIssueRepository _issueRepository;

    [BindProperty] public Issue? Issue { get; set; }

    public EditIssueModel(ILogger<IndexModel> logger, IIssueRepository issueRepository) {
        _logger = logger;
        _issueRepository = issueRepository;
    }

    public IActionResult OnGet(Guid id) {
        Issue = _issueRepository.Get().FirstOrDefault(x => x.Id == id);

        if (Issue == null) {
            return RedirectToPage("/Error");
        }

        return Page();
    }

    public IActionResult OnPost() {
        if (!ModelState.IsValid) {
            return Page();
        }

        _issueRepository.Update(Issue.Id, Issue);
        return RedirectToPage("/Log");
}
}