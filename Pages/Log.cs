using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

public class LogModel : PageModel
{
    private readonly ILogger<LogModel> _logger;

    public LogModel(ILogger<LogModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

