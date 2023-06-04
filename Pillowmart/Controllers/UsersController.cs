using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pillowmart.Models;
using Pillowmart.Models.Data;
using Pillowmart.Models.ViewModels;

namespace Pillowmart.Controllers;

public class UsersController : Controller
{
    private readonly MainContext _db;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IHostEnvironment _appEnv;
    
    public UsersController(MainContext db, UserManager<User> userManager, SignInManager<User> signInManager, IHostEnvironment appEnv)
    {
        _db = db;
        _userManager = userManager;
        _signInManager = signInManager;
        _appEnv = appEnv;
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }
    
    [HttpPost]
    [ActionName("Create")]
    public async Task<IActionResult> SignUp(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Main");
            }
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }
            
        return View("SignUp", model);
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Wrong email or password");
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(
                user,
                model.Password,
                false,
                false);
            if (result.Succeeded)
            {
                return RedirectToAction("Main");
            }
            ModelState.AddModelError(string.Empty, "Wrong email or password");
        }

        return View(model);
    }
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Main");
    }

    public ViewResult Main()
    {
        return View();
    }
    
    public ViewResult About()
    {
        return View();
    }

    public IActionResult Contacts()
    {
        return View();
    }
}