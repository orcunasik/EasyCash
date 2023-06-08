using EasyCash.Dtos.Dtos.AppUserDtos;
using EasyCash.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Presentation.Controllers
{
    [Authorize]
    public class MyAccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MyAccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            AppUser values = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserUpdateDto appUserUpdateDto = new();
            appUserUpdateDto.Name = values.Name;
            appUserUpdateDto.Surname = values.Surname;
            appUserUpdateDto.PhoneNumber = values.PhoneNumber;
            appUserUpdateDto.Email = values.Email;
            appUserUpdateDto.City = values.City;
            appUserUpdateDto.District = values.District;
            appUserUpdateDto.ImageUrl = values.ImageUrl;

            return View(appUserUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserUpdateDto appUserUpdateDto)
        {
            if(appUserUpdateDto.Password == appUserUpdateDto.ConfirmPassword)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = appUserUpdateDto.Name;
                user.Surname = appUserUpdateDto.Surname;
                user.Email = appUserUpdateDto.Email;
                user.District = appUserUpdateDto.District;
                user.City = appUserUpdateDto.City;
                user.ImageUrl = "test";
                user.PhoneNumber = appUserUpdateDto.PhoneNumber;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserUpdateDto.Password);

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
