using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Data;
using FinalProject.ViewModels;

namespace FinalProject.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModels model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password != model.ConformPassword)
                {
                    ModelState.AddModelError(string.Empty, "Passwords do not match.");
                    return View(model);
                }

                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.fname,
                    LastName = model.lname,
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (await _roleManager.RoleExistsAsync(model.Role))
                    {
                        await _userManager.AddToRoleAsync(user, model.Role); // Assign selected role
                    }

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
    


public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LogInViewModels model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByEmailAsync(model.Email).Result;
                if (user is not null)
                {
                    if (_userManager.CheckPasswordAsync(user, model.Password).Result)
                    {
                        var res = _signInManager.PasswordSignInAsync(user, model.Password, false, false).Result;
                        if (res.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Incorrect email or password");
            return View();
        }

    }
}
