using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data.Interfaces;

namespace WebApp.Pages;

public class LoginModel : PageModel {
    private readonly IUserRepository _userRepository;

    public LoginModel(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    [BindProperty] public User User { get; set; }

    public void OnGet() {
    }

    public IActionResult OnPost(User User) {
        if (ModelState.IsValid) {
            var exists = _userRepository
                .Get()
                .Exists(x => x.Username == User.Username && x.Password == User.Password);

            if (exists) {
                HttpContext.Session.SetString("id", User.Id.ToString() ?? string.Empty);
                return RedirectToPage("/Index");
            }
        }

        return Page();
    }
}