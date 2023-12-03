using Microsoft.AspNetCore.Mvc;
using LostnFound.Models;
using LostnFound.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Http;

public class AuthController : Controller
{
    private readonly LostnFoundContext _dbContext;
    private readonly AuthService _authService;

    public AuthController(LostnFoundContext dbContext,AuthService authService)
    {
        _dbContext = dbContext;
        _authService = authService;
    }

    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _dbContext.Auth.FirstOrDefault(u => u.Username == model.Username && u.PasswordHash == _authService.HashPassword(model.Password));

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.UserId);
                return RedirectToAction("AllItems", "LostItem");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }
        }

        return View(model);
    }

    public ActionResult Signup()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Signup(SignupViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Check if the username is already taken
            if (_dbContext.Auth.Any(u => u.Username == model.Username))
            {
                ModelState.AddModelError(nameof(SignupViewModel.Username), "Username is already taken");
                return View(model);
            }

            // Check if the email address is already in use
            if (_dbContext.Auth.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError(nameof(SignupViewModel.Email), "Email address is already in use");
                return View(model);
            }

            // Create a new user
            var newUser = new AuthModel
            {
                Username = model.Username,
                Email = model.Email,
                PasswordHash = _authService.HashPassword(model.Password),
            };

            // Save the new user to the database
            _dbContext.Auth.Add(newUser);
            _dbContext.SaveChanges();

            ViewBag.SuccessMessage = "Sign up successful! Please log in.";
            return View("Login"); // Redirect to login page or show a success message
        }

        return View(model);
    }

    public ActionResult Signout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Auth");
    }
}
