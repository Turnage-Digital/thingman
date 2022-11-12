using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ThingMan.Pages.Account;

[SecurityHeaders]
[AllowAnonymous]
public class Login : PageModel
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public Login(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public string? ReturnUrl { get; set; }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    public IActionResult OnGet(string? returnUrl = null)
    {
        ReturnUrl = returnUrl ?? Url.Content("~/");
        return Page();
    }

    public async Task<IActionResult> OnPost(string? returnUrl = null)
    {
        ReturnUrl = returnUrl ?? Url.Content("~/");

        if (!ModelState.IsValid)
        {
            return Page();
        }

        // using that null suppressor because the model state is valid
        var result = await _signInManager.PasswordSignInAsync(Input.Email!, Input.Password!,
            true, lockoutOnFailure: false);
        if (result.Succeeded)
        {
            return LocalRedirect(ReturnUrl);
        }

        ModelState.AddModelError(string.Empty, "Invalid username or password");

        return Page();
    }

    public class InputModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; init; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; init; }
    }
}