﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data.Interfaces;

namespace WebApp.Pages;

public class BacklogModel : PageModel {
    private readonly ILogger<IndexModel> _logger;
    private readonly IIssueRepository _issueRepository;

    public List<Issue> Issues { get; set; } = new();

    public BacklogModel(ILogger<IndexModel> logger, IIssueRepository issueRepository) {
        _logger = logger;
        _issueRepository = issueRepository;
    }

    public void OnGet() {
        Issues = _issueRepository.Get();
    }
}