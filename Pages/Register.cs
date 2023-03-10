using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data.Interfaces;

namespace WebApp.Pages;

public class RegisterModel : PageModel {
    private readonly IUserRepository _userRepository;

    public RegisterModel(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    [BindProperty] public User User { get; set; }
    [BindProperty] public string ConfirmPassword { get; set; } = "";

    public void OnGet() {
    }

    public IActionResult OnPost(User User, string ConfirmPassword) {
        if (ModelState.IsValid && ConfirmPassword == User.Password) {
            var id = HttpContext.Session.GetString("id");

            _userRepository.Create(User, id);

            return RedirectToPage("/Login");
        }

        return Page();
    }
}