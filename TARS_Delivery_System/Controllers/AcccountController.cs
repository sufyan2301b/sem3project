using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TARS_Delivery_System.Models;
using TARS_Delivery_System.Models.ViewModel;

namespace TARS_Delivery_System.Controllers
{
    public class AcccountController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AcccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager=userManager;
            _signInManager=signInManager;
            _roleManager=roleManager;
        }

        public ActionResult Register()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            if (_userManager == null)
            {
                ModelState.AddModelError("", "Internal server error: User management services are unavailable.");
                return View(registerViewModel);
            }

            var existingUserByUsername = await _userManager.FindByNameAsync(registerViewModel.Username);
            var existingUserByEmail = await _userManager.FindByEmailAsync(registerViewModel.Email);

            if (existingUserByUsername != null)
            {
                ModelState.AddModelError("", "Username is already taken.");
                return View(registerViewModel);
            }

            if (existingUserByEmail != null)
            {
                ModelState.AddModelError("", "Email is already registered.");
                return View(registerViewModel);
            }

            var user = new IdentityUser
            {
                UserName = registerViewModel.Username,
                Email = registerViewModel.Email
            };

            try
            {
                var res = await _userManager.CreateAsync(user, registerViewModel.Password);

                if (res.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    // Redirect the user to the login page after successful registration
                    TempData["SuccessMessage"] = "Registration successful! Please log in to continue.";
                    return RedirectToAction("Login", "Acccount");
                }

                foreach (var err in res.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An unexpected error occurred: {ex.Message}");
            }

            return View(registerViewModel);
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Acccount");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                // Try finding the user by email or username
                var user = await _userManager.FindByEmailAsync(model.Email) ?? await _userManager.FindByNameAsync(model.Email);

                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                    return View(model);
                }

                // Attempt to sign in
                var res = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);

                if (res.Succeeded)
                {
                    var users = await _userManager.FindByEmailAsync(model.Email);

                    if(await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid Credentials");
            }
            return View(model);
        }

    }
}
