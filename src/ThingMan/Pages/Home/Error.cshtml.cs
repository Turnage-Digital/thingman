using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ThingMan.Pages.Home;

[SecurityHeaders]
[AllowAnonymous]
public class Error : PageModel
{
    public void OnGet(string? errorId = null) { }
}