using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SecureRoutesSample.Web.Data;
using System.Security.Claims;
using SecureRoutesSample.Web.Models;

namespace SecureRoutesSample.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserData _userData;

        public AccountController(UserData userData)
        {
            _userData = userData;
        }

        [HttpGet("/account/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View(user);
            }

            var authenticatedUser = _userData.GetUser(user.EmailAddress, user.Password);
            if (authenticatedUser == null)
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View(user);
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, authenticatedUser.Name ?? ""),
                new(ClaimTypes.Email, authenticatedUser.EmailAddress),
                new(ClaimTypes.Role, authenticatedUser.Role.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true
            };

            await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToAction("Index", "Home");
        }


        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
